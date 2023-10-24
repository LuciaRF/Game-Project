#pragma once
#include "Personaje.h"
class Ahufflepuff : public Personaje
{
	double vidahufflepuff = 2;
public:
	Ahufflepuff() :Personaje(100, 10, 5, 1) {
		Personaje::setvida(Personaje::getvida() + vidahufflepuff);
	}
};

