#pragma once
class Personaje
{

	double vida;
	double ataque;
	double defensa;
	double potvarita;

public:

	Personaje() {
		vida = 100;
		ataque = 10;
		defensa = 5;
		potvarita = 1;
	}


	Personaje(double newvida, double newataque, double newdefensa, double newpotencia) {
		vida = newvida;
		ataque = newataque;
		defensa = newdefensa;
		potvarita = newpotencia;
	}

	void setvida(double newvida) {
		vida = newvida;
	}
	double getvida() {
		return vida;
	}

	void setataque(double newataque) {
		ataque = newataque;
	}
	double getataque() {
		return ataque;
	}

	void setdefensa(double newdefensa) {
		defensa = newdefensa;
	}
	double getdefensa() {
		return defensa;
	}

	void setpotencia(double newpotencia) {
		potvarita = newpotencia;
	}
	double getpotencia() {
		return potvarita;
	}
};

