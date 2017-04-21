using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using LabJack.LabJackUD;

namespace natgeo
{
    [Serializable]
    public class bicycle
    {
        /// <summary>
        /// Configure this according to the steady-state voltage for zero pedal power
        /// </summary>
        public double voltageOffset = 1.8;

        /// <summary>
        /// The amount of voltage that 1A of pedal power represents in our raw reading
        /// </summary>
        public double voltagePerAmpere;

        /// <summary>
        /// Serial number of the labjack which this bike is connected to 
        /// </summary>
        public string labjackSerial;

        /// <summary>
        /// Index of the FIO port which this bike is attached to
        /// </summary>
        public int FIOChannel;

        /// <summary>
        /// A (non-unique) handle to the labjack that this bicycle is conencted to 
        /// </summary>
        [XmlIgnore]
        public int labjackHandle;

        /// <summary>
        /// The unique index of this bike, as referenced by humans, not the LJ
        /// </summary>
        public int bikeIndex;

        /// <summary>
        /// A static list of labjack handles, each indexed by the corresponding labjack serial number. This is shared between all bikes.
        /// </summary>
        [XmlIgnore]
        private static readonly Dictionary<string, int> LJDeviceHandlesBySerial = new Dictionary<string, int>();

        public delegate void newPowerReading(bicycle sender, DateTime timestamp);

        /// <summary>
        /// This is fired when new data is acquired
        /// </summary>
        [XmlIgnore]
        public newPowerReading onNewPowerReading;

        /// <summary>
        /// The last reading which we acquired, in amps 
        /// </summary>
        [XmlIgnore]
        public double lastPowerReadingA;

        /// <summary>
        /// The calculated volatage that corresponds to lastPowerReadingA
        /// </summary>
        [XmlIgnore]
        public double lastPowerReadingV;

        /// <summary>
        /// The last reading which we acquired from the labjack, raw and unprocessed 
        /// </summary>
        [XmlIgnore]
        public double lastRawValue;

        /// <summary>
        /// The calculated power that corresponds to lastPowerReadingA and lastPowerReadingV.
        /// </summary>
        [XmlIgnore]
        public double lastPowerReadingW
        {
            get { return lastPowerReadingA * lastPowerReadingV; }
        }

        public bicycle()
        {
            // for XML de/ser
            voltagePerAmpere = 75 / voltageOffset;
        }

        public bicycle(int newBikeIndex, string newLabjackSerial, int newFIOChannel)
        {
            bikeIndex = newBikeIndex;
            labjackSerial = newLabjackSerial;
            FIOChannel = newFIOChannel;
            voltagePerAmpere = 75 / voltageOffset;

            postXMLDeserialisation();
        }

        public void onRawData(double newVal)
        {
            lastRawValue = newVal;

            // Offset and scale our raw value to get a nice amperes value
            lastPowerReadingA = (newVal - voltageOffset) * voltagePerAmpere;

            // And allow either direction of current (just in case a bike is wired up wrongly!)
            lastPowerReadingA = Math.Abs(lastPowerReadingA);

            // Scale by this formula to estimate voltage output of dynamo
            // FIXME: make this subect to A not V
            /*
            lastPowerReadingV = (0.3422f * Math.Pow(lastPowerReadingA, 4)) -
                                (19.805f * Math.Pow(lastPowerReadingA, 3)) +
                                (492.22f * Math.Pow(lastPowerReadingA, 2)) - 
                                (4125.9f * lastPowerReadingA) + 14840;*/
            lastPowerReadingV = lastPowerReadingA;

            // Debug.WriteLine("Bike " + bikeIndex + " raw val " + newVal + " scaled to " + lastPowerReadingA + " A");

            onNewPowerReading.Invoke(this, DateTime.Now);
        }

        public void postXMLDeserialisation()
        {
            // Comment this out if you have a real LabJack
            return;
            if (LJDeviceHandlesBySerial.ContainsKey(labjackSerial))
            {
                labjackHandle = LJDeviceHandlesBySerial[labjackSerial];
            }
            else
            {
                // This labjack hasn't been opened yet, so lets do that.
                LJUD.OpenLabJack(LJUD.DEVICE.U3, LJUD.CONNECTION.USB, labjackSerial, false, ref labjackHandle);
                LJDeviceHandlesBySerial[labjackSerial] = labjackHandle;

                // Reset the config, in case another application has messed with it
                LJUD.AddRequest(labjackHandle, LJUD.IO.PIN_CONFIGURATION_RESET, 0, 0, 0, 0);

                // Set 12-bit sampling resolution
                LJUD.AddRequest(labjackHandle, LJUD.IO.PUT_CONFIG, LJUD.CHANNEL.AIN_RESOLUTION, 12, 0, 0);
            }

            // Configure FIO channel for this bicycle as analogue input.
            LJUD.AddRequest(labjackHandle, LJUD.IO.PUT_ANALOG_ENABLE_BIT, FIOChannel, 1, 0, 0);                  
        }
    }
}