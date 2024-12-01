using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Známka : MonoBehaviour
{
    public TextMeshProUGUI text_jméno;
    public TextMeshProUGUI text_příjmení;
    public TextMeshProUGUI text_číslo;

    void Start()
    {
        int jedna= Random.Range(0,9);
        int dva= Random.Range(0,9);
        int tři= Random.Range(0,9);
        int čtyři = Random.Range(0,9);

        text_číslo.text = "no."+jedna +""+dva+""+tři+""+čtyři;

        text_jméno.text = jména[Random.Range(0,jména.Length)];
        text_příjmení.text = příjmení[Random.Range(0,jména.Length)];
    }

    string [] jména = new string[]
    {
        "Prokop",
        "Ondrej",
        "John",
        "Mrakoplas",
        "Ministr",
        "Obavany",
        "Josef",
        "Skibiddy",
        "Drue",
        "Jan",
        "Matous",
        "Gordon",
        "Gabe",
        "Blitzo",
        "Adam",
        "Patrik",
        "Petr",
        "Major",
        "Vince",
        "Max",
        "Cernokneznik",
        "Jimmy",
        "Milos",
        "Vaclav",
        "Vermin",
        "James",
        "Seymour",
        "Superintendent",
        "Masinka",
        "Xavier",
        "Vernon",
        "Jared",
        "Ace",
        "Leto",
        "Vyvoleny",
        "Prezident",
    };
    string [] příjmení = new string[]
    {
        "Dvere",
        "Lustr",
        "Záclony",
        "Liscak",
        "Freeman",
        "Dvorak",
        "Hucko",
        "Nicitel",
        "Svejk",
        "Pork",
        "Kafemlinek",
        "Rizzler",
        "Hams",
        "Langlois",
        "Svankmajer",
        "Ostrostrelec",
        "Newell",
        "Ryba",
        "Jahoda",
        "Burval",
        "Pavel",
        "Jan",
        "Major",
        "Hus",
        "Ziska",
        "McMahon",
        "Fosh",
        "Kovar",
        "Sedlak",
        "Zababa",
        "Pat",
        "Neutron",
        "Zeman",
        "Havel",
        "Supreme",
        "Vance",
        "May",
        "Skinner",
        "Chalmers",
        "Tomas",
        "Chatman",
        "Ambling",
        "Otel"
    };
}
