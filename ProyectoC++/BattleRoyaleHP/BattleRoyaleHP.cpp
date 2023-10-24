// BattleRoyaleHP.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
#include <iostream>
#include <stdlib.h>
#include <iterator>
#include <cstdlib>
#include <list>

#include "Mortifagos.h"
#include "Agryffindor.h"
#include "Ahufflepuff.h"
#include "Aravenclaw.h"
#include "Aslytherin.h" 
#include "Personaje.h"
#include "Partida.h"

using namespace std;

void clearTerminal() {

#if defined(_WIN32)

    system("cls");

#elif defined(__unix__) || defined(__unix)
    
    system("clear");
#endif
}

int main()
{
    int menu = 1;
    int casa;
    int numenemigos;
    bool perdedor;
 

    Agryffindor g1;
    Ahufflepuff h1;
    Aravenclaw r1;
    Aslytherin s1;
    Personaje p1;
    Mortifagos enemigo;

    list<Mortifagos> listaenemigos;

    Partida partidajugador;

    while (menu == 1) {

        cout << "\t\t\t\t###################################################" << endl;
        printf("\n");
        cout << "\t\t\t\tBIENVENIDOS A LA BATALLA DE HOGWARTS BATTLE ROYALE\n\n";
        cout << "\t\t\t\t###################################################" << endl;

        cout << "\n\t\t\t\t\t\t\tLumos!\n" << endl;

        cout << "\n\t\t\t\tJuro solemnemente que mis intenciones no son buenas\n\n" << endl;

        printf("\n\t\t\t\t\t\tMENU DE JUEGO\n");
        printf("\t\t\t\t\t\t1. Instrucciones del juego\n");
        printf("\t\t\t\t\t\t2. Comienza la batalla\n");
        printf("\t\t\t\t\t\t3. Salir\n");
        printf("--> ");
        cin >> menu;

        clearTerminal();

        switch (menu)
        {
        case 1:
            cout << "\t\t\t\t###################################################" << endl;
            printf("\n\nHogwarts esta en peligro, la amenaza del resurgimiento de Voldemort es mayor que nunca y el mundo magico necesita\ntu ayuda. Los mortifagos (aliados de Voldemort) estan a las puertas de la escuela y para evitar que accedan tendras\nque enfrentarte a ellos y vencerlos");
            printf(" pero cuidado conforme consigas derrotarlos sabran de tu existencia y mejoraran\nsu capacidad de ataque con la intencion de vencerte.\n\n");
             
            printf("\nComo alumno de Hogwarts tu deber es proteger el colegio y hacer que tu casa se sienta orgullosa de ti.\n");
            printf("Recuerda que existen 4 casas y formas parte de una de ellas estas casas son Gryffindor, Hufflepuff,\nRavenclaw y Slytherin.\n\n");
            printf("\t\t\t\tLas caracteristicas basicas de las casas son:\n");
            printf("\t\t\t\t-Gryffindor los valientes de corazon y mayor ataque.\n");
            printf("\t\t\t\t-Hufflepuff leales y mayor vida.\n");
            printf("\t\t\t\t-Ravenclaw inteligentes y mayor potencia de ataque.\n");
            printf("\t\t\t\t-Slytherin rapidos y astutos su defensa es legendaria.\n\n");
            printf("\nOjo debes saber que tu eleccion de casa es importante para tus caractaristicas aunque siempre puedes dejar que el\nSombrero Seleccionador elija por ti.\n");
            printf("\nPulsa cualquier tecla para volver al menu");
            _getch();
            clearTerminal();
            break;
        case 2:
            cout << "\t\t\t\t########################################################" << endl;
            printf("\n\t\t\t\t\t\tPrimero debes elegir casa: \n");
            printf("\t\t\t\t\t\t1. Puedes ser Gryffindor\n");
            printf("\t\t\t\t\t\t2. Puedes ser Hufflepuff\n");
            printf("\t\t\t\t\t\t3. Puedes ser Ravenclaw\n");
            printf("\t\t\t\t\t\t4. Puedes ser Slytherin\n\n");
            printf("Para una experiencia mas realista puedes ser seleccionado por el sombrero seleccionador pulsando cualquier otra tecla.\n");

            printf("\n--> ");
            cin >> casa;

            if (casa != 1 && casa != 2 && casa != 3 && casa != 4) {
                srand(time(0)); //para que no se repita el numero
                casa = (rand() % 4) + 1;
            }
            switch (casa)
            {
            case 1:
                p1 = g1;
                cout << "\t\t\t\t\t\tAsi que eres de la casa Gryffindor.\n" << endl;
                break;
            case 2:
                p1 = h1;
                cout << "\t\t\t\t\t\tAsi que eres de la casa Hufflepuff.\n" << endl;
                break;
            case 3:
                p1 = r1;
                cout << "\t\t\t\t\t\tAsi que eres de la casa Ravenclaw.\n" << endl;
                break;
            case 4:
                p1 = s1;
                cout << "\t\t\t\t\t\tAsi que eres de la casa Slytherin.\n" << endl;
                break;

            default:
                cout << "Eres un poco muggle.\n" << endl;
                break;
            }

            printf("\t\t\t\tContra cuantos enemigos quieres probar suerte y enfrentarte?\n");
            printf("--> ");

            cin >> numenemigos;


            for (int i = 0; i < numenemigos; ++i) {
                listaenemigos.push_back(enemigo);
            }

            clearTerminal();

            printf("\n\t\tTen cuidado los mortifagos se acercan y tendras que vencerles para que no vuelva Lord Voldemort.\n\n");
            printf("\t\t\t\t\tTus cararcteristicas iniciales son: \n\n");
            printf("\t\t\t\t\t\tVida: %f\n", p1.getvida());
            printf("\t\t\t\t\t\tAtaque %f\n", p1.getataque());
            printf("\t\t\t\t\t\tDefensa: %f\n", p1.getdefensa());
            printf("\t\t\t\t\t\tPotencia %f\n", p1.getpotencia());

            perdedor = partidajugador.batalla(p1, listaenemigos);

            if (perdedor == false) {
                cout << "\t\t\t\t\tHas salvado a Hogwarts felicidades\n" << endl;
            }

            break;
        case 3:
            cout << "\n\t\t\t\t\t\t\tNox!\n" << endl;
            break;
        default:
            cout << "\n\t\t\t\t\t\tEres un poco muggle\n" << endl;
            break;
        }

    }
} 

