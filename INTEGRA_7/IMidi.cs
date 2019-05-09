﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INTEGRA_7
{
    public interface IMidi
    {
        void Init(INTEGRA_7.MainPage mainPage, String deviceName,
            byte MidiOutPortChannel, byte MidiInPortChannel);

        //void Init(INTEGRA_7.MainPage mainPage, String deviceName,
        //    object DeviceSpecificObject, byte MidiOutPortChannel, byte MidiInPortChannel);

        void ResetMidi();

        Boolean MidiIsReady();

        void NoteOn(byte currentChannel, byte noteNumber, byte velocity);

        void NoteOff(byte currentChannel, byte noteNumber);

        void SendControlChange(byte channel, byte controller, byte value);

        void SetVolume(byte currentChannel, byte volume);

        void ProgramChange(byte currentChannel, String smsb, String slsb, String spc);

        void ProgramChange(byte currentChannel, byte msb, byte lsb, byte pc);

        void SendSystemExclusive(byte[] bytes);

        byte[] SystemExclusiveDT1Message(byte[] Address, byte[] DataToTransmit);

        byte[] SystemExclusiveRQ1Message(byte[] Address, byte[] Length);

        //void OutputDeviceChanged(Picker DeviceSelector);

        //void InputDeviceChanged(Picker DeviceSelector);

        byte GetMidiOutPortChannel();

        void SetMidiOutPortChannel(byte OutPortChannel);

        byte GetMidiInPortChannel();

        void SetMidiInPortChannel(byte InPortChannel);

        void AllNotesOff(byte currentChannel);

        void CheckForVenderDriver();

        Boolean VenderDriverDetected();

        void MakeMidiDeviceList();

        List<String> GetMidiDeviceList();
    }
}
