#pragma once

#include <iostream>
#include <conio.h>
#include <iterator>
#include <cstdlib>
#include <list>

#include "Personaje.h"
#include "Mortifagos.h"
#include "Item.h"

using namespace std;


class Partida
{
public:
   

    bool batalla(Personaje& p, list<Mortifagos>& m) {

        list<Mortifagos>::iterator it;
        list<Mortifagos>::iterator itoriginal;
        itoriginal=m.begin();;
        list<Mortifagos>::iterator itsiguiente;
        itsiguiente = m.begin()++;

        int ronda = 0;
        int rondas = m.size();
        bool perdedor = false;
        
        Personaje pauxiliar = p;

        for(it = m.begin(); it != m.end(); ++it){
        Mortifagos mauxiliar = (*itoriginal); //que tenga el valor inicial
            
            if (rondas > 0 && perdedor == false) {
            ronda++;
            system("cls");
            cout << "\t\t\t#############################################################" << endl;
            printf("\n\t\t\t\t\t\tRonda %d\n\n", ronda);

            perdedor = duelo( pauxiliar,itoriginal,itsiguiente,m,mauxiliar);
            rondas--;     
            }

            
        }
        return perdedor;
    }

    bool duelo(Personaje &pauxiliar, list<Mortifagos>::iterator &itoriginal, list<Mortifagos>::iterator &itsiguiente,list<Mortifagos>& m, Mortifagos &mauxiliar ) {


        bool perdedor = false;
        bool aviso = true;

        double resistenciapersonaje = pauxiliar.getvida() + pauxiliar.getdefensa();
        double resistenciapersonajecheck = resistenciapersonaje / 2;
        double ataquepersonaje = pauxiliar.getataque() * pauxiliar.getpotencia();

        double resistenciaenemigo = mauxiliar.getvida() + mauxiliar.getdefensa();
        double resistenciaenemigocheck = resistenciaenemigo / 2;
        double ataqueenemigo = mauxiliar.getataque() * mauxiliar.getpotencia();

        while (resistenciapersonaje >= 0 && resistenciaenemigo >= 0) {
            resistenciapersonaje = resistenciapersonaje - ataqueenemigo;
            resistenciaenemigo = resistenciaenemigo - ataquepersonaje;
            if (resistenciapersonaje < resistenciaenemigocheck && aviso == true) {
                aviso = false;
                printf("\t\t\t\t\tOjo te estas debilitando!\n\n");
                printf("\t\t\tTe queda un %f de resistencia y a tu enemigo %f\n", resistenciapersonaje, resistenciaenemigo);
                printf("\n\t\t\t\t\tPulsa una tecla para continuar\n\n");
                _getch();
            }
            

        }

           if (resistenciaenemigo <= 0) {
                cout << "\n\t\t\t\t\t\tHas ganado\n" << endl;
                perdedor = false;
                if (itoriginal != m.end()) {
                    subirnivel(itoriginal, itsiguiente, mauxiliar, m);
                    *itsiguiente = mauxiliar;

                    combate(pauxiliar,mauxiliar);
                }
            }
            else {
                cout << "\n\t\t\t\t\tHas perdido y Voldemort ha regresado\n";
                perdedor = true;              
            }
          
           return perdedor;

    }

    void subirnivel(list<Mortifagos>::iterator itotiginal, list<Mortifagos>::iterator &itsiguiente, Mortifagos &enemigoactual, list<Mortifagos>& m) {
        

        if(itotiginal != m.end()){
            list<Mortifagos>::iterator iteradorsig = itsiguiente;
            Mortifagos enemigosig = *iteradorsig; //valores enemigo siguiente
            enemigosig.setataque(enemigosig.getataque() * 1.2);
            enemigoactual = enemigosig;

        }  

    }


    void combate(Personaje &jugador, Mortifagos enemigo) {

        Item item;
        int valoritem;

            printf("\t\tCuidado los mortifagos estan avanzado toma una recompensa por tu trabajo y sigue adelante\n");
            printf("\t\t\t\t\t\tQue prefieres?\n\n\t\t\t\t\t1. Las grageas te daran mas potencia de ataque\n\t\t\t\t\t2. Las ranas de chocolate te daran mas vida\n\t\t\t\t\t3. La cerveza de mantequilla mejora tu defensa\n");
            printf("--> ");
            cin >> valoritem;

            switch (valoritem)
            {
            case 1:
                printf("\t\t\tHas elegido una gragea Bertie Botts, ojala no sepa a cera de oidos\n\n");
                jugador.setataque(jugador.getataque() * (1 + item.tomaunagragea()));
                break;
            case 2:
                printf("\t\t\tHas elegido una rana de chocolate, cometela antes de que se escape\n\n");
                jugador.setvida(jugador.getvida() + item.tomaunarana());
                break;
            case 3:
                printf("\t\tHas elegido una cerveza de mantequilla, bebetela pronto que se le van las vitaminas\n\n");
                jugador.setdefensa(jugador.getdefensa() + item.tomaunacev());
                break;
            default:
                printf("\t\t\tNo has elegido nada, suerte la vas a necesitar.\n");
                break;
            }
            printf("\t\t\t\t\tTus cararcteristicas ahora son: \n\n");
            printf("\t\t\t\t\t\tVida: %f\n", jugador.getvida());
            printf("\t\t\t\t\t\tAtaque %f\n", jugador.getataque());
            printf("\t\t\t\t\t\tDefensa: %f\n", jugador.getdefensa());
            printf("\t\t\t\t\t\tPotencia %f\n", jugador.getpotencia());

            printf("\n\t\t\t\t\tPulsa una tecla para continuar\n\n");
            _getch();
        }

};

