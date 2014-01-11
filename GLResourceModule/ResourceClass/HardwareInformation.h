////////////////////////////////////////////////////////////
//                GLauncher (GLModule)                    //
//                       GTeam                            //
//  Este é um projeto Open Source, mantenha os créditos   //
//               MeTaL,Oxyfgp,tDarkFall                   //
//                                                        //
//                  LAUS DEO SEMPER!                      //
////////////////////////////////////////////////////////////

#pragma once
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Management;
using namespace System::Runtime::InteropServices;
namespace GLResourceModule
{
	public enum class MemoryType
	{
		_3DRAM = 0x10,
		CacheRAM = 4,
		CDRAM = 15,
		DDR = 20,
		DDR2 = 0x15,
		DRAM = 2,
		EDO = 5,
		EDRAM = 6,
		EEPROM = 12,
		EPROM = 14,
		FEPROM = 13,
		Flash = 11,
		Other = 1,
		RAM = 9,
		RDRAM = 0x13,
		ROM = 10,
		SDRAM = 0x11,
		SGRAM = 0x12,
		SRAM = 8,
		SynchronousDRAM = 3,
		Unknown = 0,
		VRAM = 7
	};

	public ref class MemoryInformation
	{
	public:
		property MemoryType MemoryType;
		property String^ Name;
		property UInt64^ TotalSize; //In MB

	internal:
		MemoryInformation(void) { };
	};


	public enum class StatusGPU
	{
		Disabled = 4,
		Enabled = 3,
		NotApplicable = 5,
		Other = 1,
		Unknown = 2
	};

	public ref class GPUInformation
	{
		//Leia antes de fazer modificações
		//http://support.microsoft.com/kb/2787534/pt-br
	public: 
		property String^ AdapterVideoName;
		property UInt32^ DedicatedMemory; //In MB
		property String^ Description;
		property String^ DriverVersion;
		property List<String^>^ Resolution;
		property StatusGPU Status;
	internal:
		GPUInformation(void) { };
	};


	public enum class Architecture
	{
		Alpha = 2,
		ARM = 5,
		ItaniumBased_Systems = 6,
		MIPS = 1,
		PowerPC = 3,
		x64 = 9,
		x86 = 0
	};

	public ref class CPUInformation
	{
		//Leia antes de fazer qualquer modificação
		//http://support.microsoft.com/kb/953955/pt-br 
	public:
		property Architecture Architecture;
		property UInt32^ ClockSpeed; 
		property UInt32^ Family;
		property String^ Manufacturer;
		property String^ Name;
		property UInt32^ NumberOfCores;//Não disponível para Windows XP e Windows Server 2003

	internal:
		CPUInformation(void) { };
	};
	public ref class HardwareInformation abstract sealed
	{
	public:
		static property CPUInformation^ CPUInfo
		{
			CPUInformation^ get()
			{
				if(m_CPUInfo == nullptr)
					m_CPUInfo = HardwareInformation::GetCPUInfo();
				return m_CPUInfo;
			}
		}
		static property array<GPUInformation^>^ GPUInfo
		{
			array<GPUInformation^>^ get()
			{
				if(m_GPUInfo == nullptr)
					m_GPUInfo = HardwareInformation::GetGPUInfo();
				return m_GPUInfo;
			}
		}
		static property array<MemoryInformation^>^ MemoryInfo
		{
			array<MemoryInformation^>^ get()
			{
				if(m_MemoryInfo == nullptr)
					m_MemoryInfo = HardwareInformation::GetMemoryInfo();
				return m_MemoryInfo;
			}
		}

		static array<GPUInformation^>^ GetGPUInfo();
		static array<MemoryInformation^>^ GetMemoryInfo();
		static CPUInformation^ GetCPUInfo();

	private:
		static CPUInformation^ m_CPUInfo;
		static array<GPUInformation^>^ m_GPUInfo;
		static array<MemoryInformation^>^ m_MemoryInfo;
	};
}
