#pragma once
#include "Personaje.h"
class Aravenclaw :public Personaje
{
	double potravenclaw = 1.1;
public:
	Aravenclaw() :Personaje(100, 10, 5, 1) {
		Personaje::setpotencia(Personaje::getpotencia() * potravenclaw);
	}
};

