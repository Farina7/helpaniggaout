using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    /* ##### IMPORTANTE PER LA PROSSIMA LEZIONE MIGLIOREREMO QUESTO CODICE, CI SARA LA SPIEGAZIONE DI COME PREVENIRE ERRORI DA PARTE DELL'UTENTE ##### */   
    /* ##### INOLTRE SI AGGIUNGERA LA POSSIBILITA DI UTILIZZARE IL NUMERO GIA CALCOLATO PER FARE ALTRE OPERAZIONI O PERMETTERE DI CREARE UNA NUOVA OPERAZIONE ##### */
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("inserisci un numero");

            //la variabile "risultato in questo caso è inutile visto che si passano i dati al metodo e la logica è tutta li dentro
           // int risultato = 0;
            int FirstNumber = Convert.ToInt32(Console.ReadLine());

            /* ### OLD CODE ### */
            //Console.WriteLine("inserisci altro numero");
            //int secondNUmber = Convert.ToInt32(Console.ReadLine());

            //qui hai creato una variabile con solo del testo quindi quando cercavi di fare qualsiasi operazione ritornava solo la stringa 
            //"inserisci segno(/,+,-,*):" senza fare nessuna operazione 

            /* ### OLD CODE ### */
            //string segno = ("inserisci segno(/,+,-,*):");
            Console.Write("inserisci segno(/,+,-,*):");
            // ricorda questa è una variabile - string è il tipo della variabile - "segno" invece è il nome e questo può essere quello che vuoi
            string segno = Console.ReadLine();


            //cosa importante per più avanti, cerca di pensare come funzionano le cose logicamente, per esempio ho spostato la selezione del secondo numero dopo il simbolo
            //questo perché 
            Console.WriteLine("inserisci altro numero");
            int SecondNumber = Convert.ToInt32(Console.ReadLine());

            switch (segno)
            {
                case "+":
                    //qua va bene e sarebbe ancora meglio se invece di fare l'operazioni qua, li mettevi in dei metodi creati apposta per ogni operazione

                    /* ### OLD CODE ### */
                    //risultato = FirstNumber + secondNUmber;
                    //Console.WriteLine("somma: " + risultato);

                    /* ### OLD CODE ### */
                    //Console.WriteLine(AddNumbers(FirstNumber, secondNUmber));

                    // questo qua sopra è un esempio di un metodo, però si può migliorare, questo metodo permette solo di addizzionare
                    //infatti si può eliminare un po' di codice creando un metodo generico dove invece di passargli solo i numeri,
                    ///gli si passano tutti i dati che gli servono
                    Console.WriteLine(NumbersOperationsMachine(FirstNumber, SecondNumber, segno, "Addizzione: "));

                    break;

                case "-":
                    Console.WriteLine(NumbersOperationsMachine(FirstNumber, SecondNumber, segno, "Sottrazione: "));
                    break;
                case "*":
                    Console.WriteLine(NumbersOperationsMachine(FirstNumber, SecondNumber, segno, "Moltiplicazione: "));
                    break;

                case "/":

                    /* ### OLD CODE ### */
                    // Console.WriteLine("divisione:" + risultato);
                    //qui ti eri dimenticato di mettere il break, quindi andava in errore e non permetteva di far partire il programma
                    //in oltre mancava la logica per fare l'operazione

                    Console.WriteLine(NumbersOperationsMachine(FirstNumber, SecondNumber, segno, "Divisione: "));
                    break;

                //qui manca il deafult, quando fai uno switch, il deafult serve a specificare un caso in cui non ha trovato un match
                //per esempio in questo caso serve a dare un messaggio nel caso l'input che gli viene passato non è un operatore matematico
                default:
                    Console.WriteLine("Spiacente, ma non è stato possibile fare l'operazione");
                    break;
            }
        }

        //qui gli creo un metodo solo per addizionare i numeri 
        private static string AddNumbers(int FirstNumber, int secondNUmber)
        {
            //per il metodo, imposto che sia un metodo con un'autorizzazione di private, cioè è visibile solo in questo file
            //gli dico che deve tornare una stringa, quindi quando viene richiamato nel codice devi considerarlo come una stringa
            //gli ho dato il nome "AddNumbers" è modificabile e lo sceglie il programmatore
            //infine gli passo due variabili che sono il primo ed il secondo  numero, in modo che la logica venga fatta qua
            //questo ti permette di avere un codice più pulito e riutilizzabile 

            return "somma: " + FirstNumber + secondNUmber;
            
        }

        private static string NumbersOperationsMachine(int FirstNumber, int secondNUmber, string operatorSymbol, string nameOfOperation)
        {
            int risultato = 
                operatorSymbol == "+" ? FirstNumber + secondNUmber :
                operatorSymbol == "-" ? FirstNumber - secondNUmber :
                operatorSymbol == "*" ? FirstNumber * secondNUmber :
                operatorSymbol == "/" ? FirstNumber / secondNUmber : 0;
            //in questo caso sto usando un operatore chiamato ternario, questo funziona come l'if però ti permette di scriverlo con molto meno codice
            //N.B. ricordati di usare i giusti comandi nel giusto modo, in questo caso va bene usare i ternari perché serve a valorizzare la variabile
            //"risultato", però non sempre puoi o non è giusto utilizzarlo, tranquillo con tempo ed esperienza imparerai come si usa e a cosa serve :^)
            return nameOfOperation + ": " + risultato;

            //se noti in questo caso abbiamo dovuto creare una variabile, mentre nel metodo che faceva solo le addizzioni potevamo mettere direttamente il risultato dell'operazione
            //questo è perché qui ci serve prima trovare il valore facendo un'operazione LOGICA per far tornare il risultato, - consiglio: guardati bene come funzionano le operazioni logiche/ booleane -
            //mentre nel metodo AddNumbers, serve fare solamente un'operazione MATEMATICA
        }

        // i metodi te li lascio entrambi almeno hai l'esempio di come funziona un metodo più specifico ed uno generico
    }
}