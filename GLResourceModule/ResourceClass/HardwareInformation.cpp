////////////////////////////////////////////////////////////
//                GLauncher (GLModule)                    //
//                       GTeam                            //
//  Este é um projeto Open Source, mantenha os créditos   //
//               MeTaL,Oxyfgp,tDarkFall                   //
//                                                        //
//                  LAUS DEO SEMPER!                      //
////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "wtypes.h"
#include <string>
#include <sstream>
#include <iostream>
#include "HardwareInformation.h"

using namespace GLResourceModule;
using namespace std;
CPUInformation^ HardwareInformation::GetCPUInfo()
{
	try
	{
		ManagementObjectSearcher^ processorReader = gcnew ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
		ManagementObjectCollection^ processorColletion = processorReader->Get();
		for each(ManagementObject^ c in processorColletion)
		{
			CPUInformation^ cpuInfo = gcnew CPUInformation();
			cpuInfo->Architecture = (Architecture)((UInt16)c["Architecture"]);
			cpuInfo->ClockSpeed = (UInt32)(c["CurrentClockSpeed"]);
			cpuInfo->Family = (UInt16)(c["Family"]);
			cpuInfo->Manufacturer = (String^)(c["Manufacturer"]);
			cpuInfo->Name = (String^)(c["Name"]);
			cpuInfo->NumberOfCores = (UInt32)(c["NumberOfCores"]);
			return cpuInfo;
		}
	}
	catch(Exception^)
	{ return nullptr; }
	return nullptr;
}

array<MemoryInformation^>^ HardwareInformation::GetMemoryInfo()
{
	try
	{
		ManagementObjectSearcher^ memoryReader = gcnew ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
		ManagementObjectCollection^ memoryCollection = memoryReader->Get();
		array<MemoryInformation^>^ MemoryArray = gcnew array<MemoryInformation^>(memoryCollection->Count);
		int i = 0;
		for each(ManagementObject^ c in memoryCollection)
		{
			MemoryArray[i] = gcnew MemoryInformation();
			MemoryArray[i]->MemoryType = static_cast<MemoryType>(c["MemoryType"]);
			MemoryArray[i]->Name = (String^)(c["Name"]);
			MemoryArray[i]->TotalSize = (UInt64)c["Capacity"] / 1048576;
			i++;
		}
		return MemoryArray;
	}
	catch(Exception^)
	{
		return nullptr;
	}
}

List<String^>^ GetResolution()
{
	List<String^>^ ReturnValue = gcnew List<String^>();
	DEVMODE dm = {0};
	dm.dmSize = sizeof(dm);
	for(int i = 0; EnumDisplaySettings(NULL,i, &dm) != 0; i++)
	{
		String^ Value = dm.dmPelsWidth + "x" + dm.dmPelsHeight;
		if(ReturnValue->IndexOf(Value) == -1)
			ReturnValue->Add(Value);
	}
	return ReturnValue;
};

array<GPUInformation^>^ HardwareInformation::GetGPUInfo()
{
	try
	{
		ManagementObjectSearcher^ gpuReader = gcnew ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
		ManagementObjectCollection^ gpuCollection = gpuReader->Get();
		array<GPUInformation^>^ GPUArray = gcnew array<GPUInformation^>(gpuCollection->Count);
		int i = 0;
		for each(ManagementObject^ c in gpuReader->Get())
		{
			GPUArray[i] = gcnew GPUInformation();
			GPUArray[i]->AdapterVideoName = (String^)(c["Name"]);
			GPUArray[i]->DedicatedMemory = (UInt32)c["AdapterRam"] / (UInt32)1048576;
			GPUArray[i]->Description = (String^)c["Description"];
			GPUArray[i]->DriverVersion = (String^)c["DriverVersion"];
			GPUArray[i]->Status = cli::safe_cast<StatusGPU>(c["StatusInfo"] == nullptr ? 2 : c["StatusInfo"]);
			GPUArray[i]->Resolution = GetResolution();
			i++;
		}
		return GPUArray;
	}
	catch(Exception^)
	{
		return nullptr;
	}
};

void HardwareInformation::ReadHardware()
{
	if(m_MemoryInfo == nullptr)
		m_MemoryInfo = HardwareInformation::GetMemoryInfo();

	if(m_GPUInfo == nullptr)
		m_GPUInfo = HardwareInformation::GetGPUInfo();

	if(m_CPUInfo == nullptr)
		m_CPUInfo = HardwareInformation::GetCPUInfo();
};