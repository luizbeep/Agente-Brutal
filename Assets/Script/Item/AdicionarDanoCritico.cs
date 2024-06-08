using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Item
{
    class AdicionarDanoCritico : MonoBehaviour{
        public void addDanoCritico()
        {
            Vida danoMonstro = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Vida>();
            danoMonstro.critico = 1;
            Shooting arma = GameObject.FindGameObjectWithTag("heroi").GetComponent<Shooting>();
            arma.itemColetado = true;
        }
    }
}
