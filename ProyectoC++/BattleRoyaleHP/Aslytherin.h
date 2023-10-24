#pragma once
#include "Personaje.h"
class Aslytherin : public Personaje
{
	double defslytherin = 2;
public:
	Aslytherin() :Personaje(100, 10, 5, 1) {
		Personaje::setdefensa(Personaje::getdefensa() + defslytherin);
	}
};

