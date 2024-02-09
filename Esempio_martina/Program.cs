
// ESEMPIO 3: 
// -> aggiungere una nuova richiesta preliminare all'utente chiedendogli qual è il valore
// soglia che desidera considerare per la stampa successiva all'inserimento

// -> modificare la funzione di inserimento "AcquisisciInteroDaConsole" affinchè sia più flessibile:
// anzichè avere i due parametri "min" e "max" come dati di tipo "int", utilizzare degli int nullabili
// con il seguente significato -> se una delle due soglie è null, significa che quella soglia non si applica.
// utilizzare la nuova funzione potenziata per la parte di acquisizione dei numeri da parte dell'utente
// affinchè i numeri che egli inserisce debbano essere maggiori di 0 ma senza alcun valore massimo


// ESEMPIO 2: acquisizione di un numero variabile di numeri interi in ingresso,
// restituendo in output solo quelli maggiori di 5

var listaNumeri = new List<int>();

int? min = Utilities.AcquisisciMinMax("Inserisci un valore minimo");
int? max = Utilities.AcquisisciMinMax("Inserisci un valore massimo");
var sogliaNumeri = Utilities.AcquisisciInteroDaConsole("Quale valore soglia desideri impostare?", min, max);
var contoNumeri = Utilities.AcquisisciInteroDaConsole("Quanti valori interi desideri inserire?", min, max);

for(var i = 0; i < contoNumeri; i++)
{
    var numeroAcquisito = Utilities.AcquisisciInteroDaConsole("Inserisci il valore numero " + (i + 1), min, max);

    listaNumeri.Add(numeroAcquisito);
}

Console.WriteLine("Completato l'inserimento dei numeri, ora quelli maggiori di " + sogliaNumeri + " verrano restituiti");

foreach(var numeroCorrente in listaNumeri)
{
    if (numeroCorrente > sogliaNumeri)
    {
        Console.WriteLine(numeroCorrente.ToString());
    }
}

Console.ReadLine();

// METODO "ALLA VECCHIA"
//for(var i = 0; i < listaNumeri.Count; i++)
//{
//    var numeroCorrente = listaNumeri[i];
//    var numeroCorrente2 = listaNumeri.ElementAt(i);

//    if (numeroCorrente > 5)
//    {
//        Console.WriteLine(numeroCorrente.ToString());
//    }

//}

public static class Utilities
{

    public static int? AcquisisciMinMax(string messaggioUtente)
    {
        int? toReturn = null;

        Console.WriteLine(messaggioUtente);
        var stringaAcquisita = Console.ReadLine();

        if(stringaAcquisita != "")
        {
            try
            {
                toReturn = Convert.ToInt32(stringaAcquisita);  
            }
            catch
            {
                Console.WriteLine("Attenzione, il numero inserito non è un intero valido");
            }
        }

        return toReturn;
    }

    public static int AcquisisciInteroDaConsole(string messaggioUtente, int? min, int? max)
    {
        if(min == null)
        {
            min = 0;
        }

        Console.WriteLine(messaggioUtente + " [il numero deve essere compreso fra " + min + "-" + max + "]");

        int? toReturn = null;

        while(toReturn == null)
        {
            var stringaAcquisita = Console.ReadLine();

            try
            {
                var numeroAcquisito = Convert.ToInt32(stringaAcquisita);

                if(max == null)
                {
                    if(numeroAcquisito >= min)
                    {
                        toReturn = numeroAcquisito;
                    }
                }
                else
                {
                    if (numeroAcquisito >= min && numeroAcquisito <= max)
                    {
                        toReturn = numeroAcquisito;
                    }

                }

            }
            catch
            {
                Console.WriteLine("Attenzione, il numero inserito non è un intero valido");
            }
        }

        return toReturn.Value;
    }
}





// ESEMPIO 1
//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Inserisci del testo, lo restituirò duplicato");

//var stringaAcquisita = Console.ReadLine();

//var risposta = MetodiEsempio.GetStringaDuplicata(stringaAcquisita);

//Console.WriteLine("Ecco il risultato:");
//Console.WriteLine(risposta);

//Console.ReadLine();



//public static class MetodiEsempio
//{
//    public static string GetStringaDuplicata(string input)
//    {
//        return input + "_" + input;
//    }
//}


