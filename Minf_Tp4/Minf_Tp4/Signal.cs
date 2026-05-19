using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minf_Tp4
{
    // =============================================
    // CLASSE DE BASE : Signal
    // Définit les attributs et comportements communs
    // à tous les types de signaux (envoi et réception)
    // =============================================
    public class Signal
    {
        // Attributs protégés accessibles dans les classes héritées
        protected ushort m_amplitude;
        protected ushort m_frequence;
        protected short m_offset;
        protected string[] m_tb_signal;

        // Accesseurs publics (encapsulation)
        public ushort Amplitude { get => m_amplitude; set => m_amplitude = value; }

        public ushort Frequence { get => m_frequence; set => m_frequence = value; }

        public short Offset { get => m_offset;  set => m_offset = value; }

        public string[] TbSignal { get => m_tb_signal; set => m_tb_signal = value; }

        // Méthodes virtuelles à redéfinir dans les sous-classes
        public virtual int EnvoyerSignal() => 0;
        public virtual int ReceptionSignal() => 0;
    }

    // =============================================
    // CLASSE : SendSignal (hérite de Signal)
    // Gère la composition et l'envoi d'une trame
    // au format texte via le port série (UART)
    // Format : !S={forme}F={freq}A={amp}O={offset}W={save}#
    // =============================================
    public class SendSignal : Signal
    {
        private bool m_sauvegarde;               
        private char[] m_tb_trameSend;           // trame convertie en tableau de caractères
        private static readonly char[] Formes = { 'S', 'C', 'T', 'D' }; // codes de formes
        public SerialPort PortSerie { get; set; } // liaison série utilisée pour l’envoi

        // Propriétés publiques
        public int FormeIndex { get; set; } // index de la forme sélectionnée (0 à 3)
        public bool Sauvegarde { get => m_sauvegarde; set => m_sauvegarde = value; }

        public char[] TrameSend { get => m_tb_trameSend; set => m_tb_trameSend = value; }


        // =============================================
        // ENCODAGE DE LA TRAME
        // Construit la chaîne à envoyer à partir des
        // valeurs courantes du signal
        // =============================================
        public string CoderTrame()
        {
            string offsetStr = Offset < 0 ? Offset.ToString("D2") : "+" + Offset.ToString("D2");

            string trame = string.Format("!S={0}F={1:D2}A={2:D2}O={3}W={4}#",
                                         Formes[FormeIndex],
                                         Frequence,
                                         Amplitude,
                                         offsetStr,
                                         Sauvegarde ? 1 : 0);

            m_tb_trameSend = trame.ToCharArray(); // stocke aussi sous forme de tableau de caractères
            return trame;
        }

        // =============================================
        // ENVOI DE LA TRAME VIA LE PORT SÉRIE
        // Retourne :  1 = succès
        //            -1 = erreur lors de l'envoi
        //             0 = port null ou fermé
        // =============================================
        public override int EnvoyerSignal()
        {
           // if (PortSerie.IsOpen != true)
            if (PortSerie != null && PortSerie.IsOpen)
            {
                try
                {
                    PortSerie.Write(CoderTrame());
                    return 1; // succès
                }
                catch
                {
                    return -1; // erreur d'envoi
                }
            }
            return 0; // port non ouvert ou null
        }
    }

    // =============================================
    // CLASSE : ReceiveSignal (hérite de Signal)
    // Gère la réception et le décodage d'une trame
    // reçue via le port série
    // =============================================
    public class ReceiveSignal : Signal
    {
        private int[] m_tb_trameReceived; // trame reçue convertie en tableau d'entiers (caractères ASCII)

        public int[] TrameReceived
        {
            get => m_tb_trameReceived;
            set => m_tb_trameReceived = value;
        }

        // =============================================
        // MARQUEUR DE RÉCEPTION
        // Implémentation minimale — à compléter selon
        // les besoins du protocole
        // =============================================
        public override int ReceptionSignal()
        {
            return 1;
        }

        // =============================================
        // DÉCODAGE DE LA TRAME REÇUE
        // Convertit chaque caractère de la trame en
        // son code ASCII (int) et le stocke dans le tableau
        // Retourne 1 si le décodage s'est bien passé
        // =============================================
        public virtual int DecoderTrame(string trame)
        {
            m_tb_trameReceived = new int[trame.Length];
            for (int i = 0; i < trame.Length; i++)
                m_tb_trameReceived[i] = trame[i];

            return 1;
        }
    }


}