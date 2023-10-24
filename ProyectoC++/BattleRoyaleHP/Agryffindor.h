#pragma once
#include <iostream>
#include "Personaje.h"
class Agryffindor : public Personaje
{
	double ataquegryffindor = 2;
public:
	Agryffindor() :Personaje(100,10,5,1) {
		Personaje::setataque(Personaje::getataque() + ataquegryffindor);
	}

};

