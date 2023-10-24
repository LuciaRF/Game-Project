#pragma once
class Mortifagos
{
	double vidaenemigo;
	double ataqueenemigo;
	double defensaenemigo;
	double potvaritaenemigo;

public:

	Mortifagos() {
		vidaenemigo = 100;
		ataqueenemigo = 10;
		defensaenemigo = 5;
		potvaritaenemigo = 1;
	}

	Mortifagos(double newvidaenemigo, double  newataqueenemigo, double newdefensaenemigo, double newpotenciaenemigo) {
		vidaenemigo = newvidaenemigo;
		ataqueenemigo = newataqueenemigo;
		defensaenemigo = newdefensaenemigo;
		potvaritaenemigo = newpotenciaenemigo;
	}

	void setvida(double newvidaenemigo) {
		vidaenemigo = newvidaenemigo;
	}
	double getvida() {
		return vidaenemigo;
	}

	void setataque(double newataqueenemigo) {
		ataqueenemigo = newataqueenemigo;
	}
	double getataque() {
		return ataqueenemigo;
	}

	void setdefensa(double newdefensaenemigo) {
		defensaenemigo = newdefensaenemigo;
	}
	double getdefensa() {
		return defensaenemigo;
	}

	void setpotencia(double newpotenciaenemigo) {
		potvaritaenemigo = newpotenciaenemigo;
	}
	double getpotencia() {
		return potvaritaenemigo;
	}

};

