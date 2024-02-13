
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

// ULTERIORE SVILUPPO: si desidera estendere i compiti della funzione "_acquisisciNumeroIntero", che
// deve restituire un int, e non più un int nullabile. Internamente, quindi, dovrà occuparsi di
// richiedere ripetutamente l'inserimento di un numero valido se ciò che è inserito non corrisponde
// ad un numero intero (dando opportuno feedback al riguardo in console) e, di conseguenza modificare/rifinire
// la logica del codice chiamante:
// si desidera che non vi sia più un unico messaggio di eccezione stampato a fronte di qualsiasi errore
// ma invece, dei messaggi più specifici che riguardano il non rispetto delle soglie minime e/o massime

var listaNumeri = new List<int>();

int? min = Utilities.AcquisisciInteroDaConsole("Inserisci il valore della soglia minima", -10, null);
int? max = Utilities.AcquisisciInteroDaConsole("Inserisci un valore massimo", null, 10);
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
        var messaggioComplessivo = _getMessaggioConWarningSoglie(messaggioUtente, min, max);
        
        Console.WriteLine(messaggioComplessivo);

        int? toReturn = null;

        while(toReturn == null)
        {
            var numeroAcquisitoNullabile = _acquisisciNumeroIntero();

            if (numeroAcquisitoNullabile != null 
                && _checkNumValidoSogliaMin(numeroAcquisitoNullabile.Value, min) 
                && _checkNumValidoSogliaMax(numeroAcquisitoNullabile.Value, max))
            {
                toReturn = numeroAcquisitoNullabile.Value;
            } 
            else
            {
                Console.WriteLine("Attenzione, il numero inserito non è un intero valido");
            }
        }

        return toReturn.Value;
    }

    private static bool _checkNumValidoSogliaMin(int numeroAcquisito, int? min)
    {
        if (min == null)
            return true;

        return numeroAcquisito >= min.Value;
    }

    private static bool _checkNumValidoSogliaMax(int numeroAcquisito, int? max)
    {
        if (max == null)
            return true;

        return numeroAcquisito <= max.Value;
    }

    private static int? _acquisisciNumeroIntero()
    {
        var stringaAcquisita = Console.ReadLine();

        try
        {
            return Convert.ToInt32(stringaAcquisita);
        }
        catch
        {
            return null;
        }
    }

    private static string _getMessaggioConWarningSoglie(string messaggioUtente, int? min, int? max)
    {
        var toReturn = messaggioUtente;

        if (min != null && max != null)
        {
            toReturn += " [il numero deve essere compreso fra " + min + ".." + max + "]";
        } 
        else if (min != null && max == null)
        {
            toReturn += " [il numero deve essere maggiore o uguale a " + min + "]";
        }
        else if(min == null && max != null)
        {
            toReturn += " [il numero deve essere minore o uguale a " + max + "]";
        }

        return toReturn;
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


