#pragma once
class Item
{
	double grageasbotts = 0.5; //potencia
	double ranaschocolate = 2; //vida
	double cevmantequilla = 1; //defensa

public:

	double tomaunagragea() {
		return grageasbotts;
	}
	double tomaunarana() {
		return ranaschocolate;
	}
	double tomaunacev() {
		return cevmantequilla;
	}
};

