﻿using Entites;
using System.Xml.Serialization;

namespace CoucheAccesDonnees.XML;
[XmlType("Client")]
public class ClientXMLDTO
{
    public Guid ClientId {get; set;}
    public string Nom{get ; set;}
    public string Prenom{get; set;}
    public List<AdresseXMLDTO> Adresses{get; set;}
    
    public ClientXMLDTO(){}
    public ClientXMLDTO(Client p_client)
    {
        this.ClientId = p_client.ClientId;
        this.Nom = p_client.Nom;
        this.Prenom = p_client.Prenom;
        this.Adresses = p_client.Adresses.ConvertAll(a => new AdresseXMLDTO(a));
    }
    public Client VersEntite()
    {
        Client versClient = new Client
            (
                ClientId,
                Nom,
                Prenom,
                Adresses.ConvertAll(a => a.VersEntite())
            );

        return versClient;
    }
}
