using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace Minf_Tp4
{
    public partial class Form1 : Form
    {
        // pour la transmission:
        static bool Save_DontSave = false;
        static bool PortCom_Selected = false;
            // Limites des paramètres du signal
        int Max_Frequency = 2000, Min_Frequency = 0;
        int Max_Amplitude = 10000, Min_Amplitude = 0;
        int Max_Offset = 5000, Min_Offset = -5000;
        private int SendCounter = 0; // Nombre de trames envoyées
        private SendSignal signal = new SendSignal();   // Objet de type SendSignal pour gérer les trames
        
        // Sécurité pour éviter les boucles infinies de mise à jour entre TB et TrackBar
        private bool isUpdating = false;

        // pour la reception:
        public delegate void ReceiverD(); // Délégué pour appel cross-thread
        public ReceiverD myDelegate;
        private const byte FirstCharacter = 0x21;  // STX : '!'
        const ushort Index_Jump = 2; // Décalage pour sauter la balise + séparateur
        public Form1()
        {
            InitializeComponent();
            // Met tout les PortCom disponible
            myDelegate = new ReceiverD(RecieveData); // Lie le délégué à la méthode de réception
            Initialization(); // initialise les outils
        }

        // ----------------------------------------------- //
        // ----------------------------------------------- //
        // ICI SE PASSE LA PARTIE TRANSMISSION DE CE CODE  //
        // ----------------------------------------------- //
        // ----------------------------------------------- //

        // =============================================
        // INITIALISATION DES CONTRÔLES
        // =============================================
        private void Initialization()
        {
            // Définition des bornes des TrackBars
            Frequency_TrackB.Maximum = Max_Frequency;
            Frequency_TrackB.Minimum = Min_Frequency;

            Offset_TrackB.Maximum = Max_Amplitude;
            Offset_TrackB.Minimum = Min_Amplitude;

            Amplitude_TrackB.Maximum = Max_Amplitude;
            Amplitude_TrackB.Minimum = Min_Amplitude;

            // Valeurs par défaut au démarrage
            FormeDropDown.SelectedIndex = 0;
            Offset_TrackB.Value = 5000;
            Amplitude_TrackB.Value = 5000;
            Frequency_TrackB.Value = 1000;

            // Calcul de la vraie valeur d'offset (centré sur 0)
            int offsetVraiValeur = Offset_TrackB.Value - Max_Offset;

            // Affichage des valeurs initiales dans les TextBox
            Offset_TB.Text = offsetVraiValeur.ToString();
            Amplitude_TB.Text = Amplitude_TrackB.Value.ToString();
            Frequency_TB.Text = Frequency_TrackB.Value.ToString();
        }

        // =============================================
        // ENVOI UNIQUE D'UNE TRAME
        // =============================================
        private void Send_Button_Click(object sender, EventArgs e)
        {
            if (PortCom_Selected)
            {
                SendCounter = 0;
                SendMessage(SendCounter); // Envoie une seule trame
            }
            
        }

        // =============================================
        // ENVOI CYCLIQUE (VIA TIMER)
        // =============================================
        private void Continous_Send_Button_Click(object sender, EventArgs e)
        {
            if (PortCom_Selected)
            {
                if (!timer.Enabled)
                {
                    // Démarrage de l'envoi cyclique
                    timer.Interval = 5;
                    SendCounter = 0;
                    timer.Start();
                    Continous_Send_Button.Text = "Stop cyclique";
                }
                else
                {
                    // Arrêt de l'envoi cyclique
                    timer.Stop();
                    Continous_Send_Button.Text = "Envoi cyclique";
                }
                
            }
        }

        // =============================================
        // ACTIVATION / DÉSACTIVATION DE LA SAUVEGARDE
        // =============================================
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (PortCom_Selected)
            {
                if (!Save_DontSave)
                {
                    Save_Button.Text = "Dont Save";
                    Save_DontSave = true;
                    signal.Sauvegarde = false;
                }
                else
                {
                    Save_Button.Text = "Save";
                    Save_DontSave = false;
                    signal.Sauvegarde = true;
                }
            }
        }
    
        // =============================================
        // OUVERTURE / FERMETURE DU PORT SÉRIE
        // =============================================
        private void Select_Button_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                // Configuration du port série
                serialPort.PortName = (string)PortComDropDown.SelectedItem;
                serialPort.BaudRate = 115200;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.RequestToSend;
                serialPort.ReadTimeout = 100;
                serialPort.WriteTimeout = 100;

                try
                {
                    serialPort.Open();
                    Select_Button.Text = "Unselect";
                    PortComDropDown.Enabled = false; // Empêche le changement de port pendant la connexion
                }
                catch
                {
                    Frequency_RB.Text = "Erreur";
                }
                PortCom_Selected = true;
                // Abonnement à l'événement de réception de données
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            else
            {
                // Fermeture du port et remise à zéro de l'interface
                serialPort.Close();
                Select_Button.Text = "Select";
                PortComDropDown.Enabled = true;
                PortCom_Selected = false;
                timer.Stop();
            }
        }

        // =============================================
        // ENVOI D'UNE TRAME VIA LE PORT SÉRIE
        // =============================================
        void SendMessage(int numeroEnvoi)
        {
            if (serialPort.IsOpen)
            {
                ComposeMessage(); // Prépare la trame à envoyer

                try
                {
                    signal.PortSerie = serialPort;
                    int resultat = signal.EnvoyerSignal(); // Transmission effective
                }
                catch
                {
                    // Vidage des buffers en cas d'erreur pour éviter des données corrompues
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    timer.Stop();
                }
            }
            else
            {
                timer.Stop();
            }
        }

        // =============================================
        // COMPOSITION DE LA TRAME À ENVOYER
        // =============================================
        void ComposeMessage()
        {
            // Transfert des valeurs de l'interface vers l'objet signal
            signal.Frequence = Convert.ToUInt16(Frequency_TrackB.Value);
            signal.Amplitude = Convert.ToUInt16(Amplitude_TrackB.Value);
            signal.Offset = Convert.ToInt16(Offset_TB.Text);
            signal.FormeIndex = FormeDropDown.SelectedIndex;
            signal.Sauvegarde = Save_DontSave;

            // Génération de la trame et affichage avec horodatage
            string message = signal.CoderTrame();
            string horodatage = DateTime.Now.ToString("HH:mm:ss");
            string nouvelleLigne = $"[{horodatage}] {message}\n";
            Transmission_TB.Text = nouvelleLigne ;
        }

        // =============================================
        // SYNCHRONISATION TEXTBOX → TRACKBAR (FRÉQUENCE)
        // =============================================
        private void Frequency_TB_TC(object sender, EventArgs e)
        {
            if (isUpdating) return;

            
            if (int.TryParse(Frequency_TB.Text, out int Val_FrequencyTB))
            {
                // Clamp de la valeur dans les bornes autorisées
                if (Val_FrequencyTB > Max_Frequency)
                {
                    Val_FrequencyTB = Max_Frequency;
                    Frequency_TB.Text = "2000";
                }
                else if (Val_FrequencyTB < Min_Frequency)
                {
                    Val_FrequencyTB = Min_Frequency;
                    Frequency_TB.Text = "0";
                }
                isUpdating = true; 
                Val_FrequencyTB = Math.Max(Frequency_TrackB.Minimum, Math.Min(Frequency_TrackB.Maximum, Val_FrequencyTB));
                Frequency_TrackB.Value = Val_FrequencyTB;
                isUpdating = false; 
            }
        }

        // =============================================
        // SYNCHRONISATION TEXTBOX → TRACKBAR (AMPLITUDE)
        // =============================================
        private void Amplitude_TB_TC(object sender, EventArgs e)
        {
            if (isUpdating) return;


            if (int.TryParse(Amplitude_TB.Text, out int Val_AmplitudeTB))
            {
                if (Val_AmplitudeTB >Max_Amplitude)
                {
                    Val_AmplitudeTB = Max_Amplitude;
                    Amplitude_TB.Text = "10000";
                }
                else if (Val_AmplitudeTB < Min_Amplitude)
                {
                    Val_AmplitudeTB = Min_Amplitude;
                    Amplitude_TB.Text = "0";
                }
                isUpdating = true; 
                Val_AmplitudeTB = Math.Max(Amplitude_TrackB.Minimum, Math.Min(Amplitude_TrackB.Maximum, Val_AmplitudeTB));
                Amplitude_TrackB.Value = Val_AmplitudeTB;
                isUpdating = false;
            }
        }

        // =============================================
        // SYNCHRONISATION TEXTBOX → TRACKBAR (OFFSET)
        // =============================================
        private void Offset_TB_TC(object sender, EventArgs e)
        {
            if (isUpdating) return;

            if (int.TryParse(Offset_TB.Text, out int Val_OffsetTB))
            {
                if (Val_OffsetTB > Max_Offset)
                {
                    Val_OffsetTB = Max_Offset;
                    Offset_TB.Text = "5000";
                }
                else if (Val_OffsetTB < Min_Offset)
                {
                    Val_OffsetTB = Min_Offset;
                    Offset_TB.Text = "-5000";
                }
                isUpdating = true;
                // Conversion : l'offset réel [-5000, 5000] → position TrackBar [0, 10000]
                int positionTrackBar = Val_OffsetTB + Max_Offset;
                
                positionTrackBar = Math.Max(Offset_TrackB.Minimum, Math.Min(Offset_TrackB.Maximum, positionTrackBar));
                Offset_TrackB.Value = positionTrackBar;
                isUpdating = false; 
            }
        }

        // =============================================
        // SYNCHRONISATION TRACKBAR → TEXTBOX (OFFSET)
        // =============================================
        private void Offset_TrackB_VC()
        {
            if (isUpdating) return;
            // Arrondi au pas de 100 
            int pas = 100; 
            int valeurArrondie = (int)(Math.Round((double)Offset_TrackB.Value / pas) * pas);

            
            if (valeurArrondie > Offset_TrackB.Maximum) valeurArrondie = Offset_TrackB.Maximum;
            if (valeurArrondie < Offset_TrackB.Minimum) valeurArrondie = Offset_TrackB.Minimum;
            isUpdating = true; 
            if (Offset_TrackB.Value != valeurArrondie)
            {
                Offset_TrackB.Value = valeurArrondie ;
            }

            // Reconversion en valeur réelle centrée sur 0
            int valeurArrondieVrai = valeurArrondie - Max_Offset;
            Offset_TB.Text = valeurArrondieVrai.ToString();

            isUpdating = false; 
        }

        // =============================================
        // SYNCHRONISATION TRACKBAR → TEXTBOX (AMPLITUDE)
        // =============================================
        private void Amplitude_TrackB_VC()
        {
            if (isUpdating) return;

            int pas = 100; 

            int valeurArrondie_Amplitude = (int)(Math.Round((double)Amplitude_TrackB.Value / pas) * pas);

            
            if (valeurArrondie_Amplitude > Amplitude_TrackB.Maximum) valeurArrondie_Amplitude = Amplitude_TrackB.Maximum;
            if (valeurArrondie_Amplitude < Amplitude_TrackB.Minimum) valeurArrondie_Amplitude = Amplitude_TrackB.Minimum;
            isUpdating = true; 
            if (Amplitude_TrackB.Value != valeurArrondie_Amplitude)
            {
                Amplitude_TrackB.Value = valeurArrondie_Amplitude;
            }
            Amplitude_TB.Text = valeurArrondie_Amplitude.ToString();
            isUpdating = false; 
        }

        // =============================================
        // SYNCHRONISATION TRACKBAR → TEXTBOX (FRÉQUENCE)
        // =============================================
        private void Frequency_TrackB_VC()
        {
            if (isUpdating) return;

            int pas = 10;

            int valeurArrondieFrequency = (int)(Math.Round((double)Frequency_TrackB.Value / pas) * pas);

            
            if (valeurArrondieFrequency > Frequency_TrackB.Maximum) valeurArrondieFrequency = Frequency_TrackB.Maximum;
            if (valeurArrondieFrequency < Frequency_TrackB.Minimum) valeurArrondieFrequency = Frequency_TrackB.Minimum;
            isUpdating = true; 
            if (Frequency_TrackB.Value != valeurArrondieFrequency)
            {
                Frequency_TrackB.Value = valeurArrondieFrequency;
            }
            Frequency_TB.Text = valeurArrondieFrequency.ToString();
            isUpdating = false;
        }

        // =============================================
        // CHARGEMENT DE LA LISTE DES PORTS COM
        // =============================================
        private void PortComDropDown_DD(object sender, EventArgs e)
        {
            // clear la liste à chaque "drop down"
            PortComDropDown.Items.Clear();
            // add une nouvelle liste de port com
            string[] portsDisponibles = SerialPort.GetPortNames();
            PortComDropDown.Items.AddRange(portsDisponibles);
        }

        // =============================================
        // TICK DU TIMER (ENVOI CYCLIQUE)
        // =============================================
        private void timer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                SendCounter++;
                SendMessage(SendCounter);
            }
            else
            {
                Select_Button.Text = "Select";
            }
        }


        // ----------------------------------------------- //
        // ----------------------------------------------- //
        // ICI SE PASSE LA PARTIE RECEPTION DE CE CODE     //
        // ----------------------------------------------- //
        // ----------------------------------------------- //

        // =============================================
        // GESTIONNAIRE D'ÉVÉNEMENT DE RÉCEPTION SÉRIE
        // =============================================
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // On utilise BeginInvoke car le port série tourne sur un autre fil (Thread) 
            // que l'interface graphique (UI)
            this.BeginInvoke(myDelegate);
        }

        // =============================================
        // DÉCODAGE ET AFFICHAGE DE LA TRAME REÇUE
        // =============================================
        public void RecieveData()
        {
            ushort lectureIndex = 0;
            ushort writeIndex = 0;
            byte[] receptionTampon = new byte[30];

            ushort formIndex = 0, frequencyIndex = 0, amplitudeIndex = 0, offsetIndex = 0, saveIndex = 0;
            string receptionTrame = "";
            int temporaryValue = 0;
            do
            {
                receptionTampon[0] = (byte)serialPort.ReadByte();
            } while (receptionTampon[0] != FirstCharacter);

            if (serialPort.BytesToRead >= 18)
            {
                do
                {
                    if (serialPort.BytesToRead > 0)
                    {
                        lectureIndex++;
                        receptionTampon[lectureIndex] = (byte)serialPort.ReadByte();

                        // Enregistre les positions des balises
                        if ((receptionTampon[lectureIndex] == 'S') && (formIndex == 0)) formIndex = lectureIndex;
                        else if (receptionTampon[lectureIndex] == 'F') frequencyIndex = lectureIndex;
                        else if (receptionTampon[lectureIndex] == 'A') amplitudeIndex = lectureIndex;
                        else if (receptionTampon[lectureIndex] == 'O') offsetIndex = lectureIndex;
                        else if (receptionTampon[lectureIndex] == 'W') saveIndex = lectureIndex;
                    }

                } while (receptionTampon[lectureIndex] != 0x23);

                char whatForme = (char)receptionTampon[formIndex + 2];
                switch (whatForme)
                {
                    case 'S': Form_RB.Text = "Sinus"; break;
                    case 'C': Form_RB.Text = "Carré"; break;
                    case 'T': Form_RB.Text = "Triangle"; break;
                    case 'D': Form_RB.Text = "Dent de scie"; break;
                    default: break;
                }

                temporaryValue = 0;
                writeIndex = Index_Jump;
                for (writeIndex += frequencyIndex; writeIndex < amplitudeIndex; writeIndex++)
                    temporaryValue = temporaryValue * 10 + receptionTampon[writeIndex] - '0';
                Frequency_RB.Text = temporaryValue.ToString();

                temporaryValue = 0;
                writeIndex = Index_Jump;
                for (writeIndex += amplitudeIndex; writeIndex < offsetIndex; writeIndex++)
                    temporaryValue = temporaryValue * 10 + receptionTampon[writeIndex] - '0';
                Amplitude_RB.Text = temporaryValue.ToString();

                temporaryValue = 0;
                writeIndex = Index_Jump + 1;
                for (writeIndex += offsetIndex; writeIndex < saveIndex; writeIndex++)
                    temporaryValue = temporaryValue * 10 + receptionTampon[writeIndex] - '0';
                if (receptionTampon[offsetIndex + Index_Jump] == '-')
                    temporaryValue *= -1;
                Offset_RB.Text = temporaryValue.ToString();

                // Reconstitution de la trame complète pour affichage
                receptionTrame = "";
                for (writeIndex = 0; writeIndex <= lectureIndex; writeIndex++)
                    receptionTrame += ((char)receptionTampon[writeIndex]).ToString();

                Recieve_RB.Text = receptionTrame;
            }
        }
        
    }
}
