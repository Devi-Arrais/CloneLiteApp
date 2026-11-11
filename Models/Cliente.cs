using System;

namespace CloneLiteApp.Models
{
    public class Cliente
    {
        public int id {get; set;}        
        public string nome {get; set;} = string.Empty;
        public string? cpf {get; set;}
        public DateTime? data_nascimento{get; set;}
        public string? email{get; set;}        
        public string? celular{get; set;}
        public string? cep{get; set;}
        public string? rua{get; set;}
        public string? numero_casa{get; set;}        
        public string? complemento{get; set;}
        public string? bairro{get; set;}
        public string? cidade{get; set;}
        public string? uf{get; set;}
        public string? observacoes{get; set;}            
        public Boolean ativo{get; set;} = true;
        public DateTime data_criacao{get; set;} = DateTime.UtcNow;

    }

}