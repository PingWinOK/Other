#include<stdio.h>


struct microcontroller
{
	char* Name;
	char* Name_Core;
	int Ram;
	int Flash;
};

void main()
{
	struct microcontroller STM32F407VG = { "STM32F407VG", "Cortex-M4F",	192, 1024};
	printf("Name: %s \t Name Core: %s \t Ram: %d \t Flash: %d \n", STM32F407VG.Name, STM32F407VG.Name_Core, STM32F407VG.Ram, STM32F407VG.Flash);
	STM32F407VG.Ram = 100;
	STM32F407VG.Name_Core = "Cortex-M6F";
	printf("Name: %s \t Name Core: %s \t Ram: %d \t Flash: %d", STM32F407VG.Name, STM32F407VG.Name_Core, STM32F407VG.Ram, STM32F407VG.Flash);
	return 0;
}