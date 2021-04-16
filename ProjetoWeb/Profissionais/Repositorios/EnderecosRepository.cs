using Profissionais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Profissionais.Repositorios
{
    public interface IEnderecosRepository
    {
        Task<List<Endereco>> GetEnderecos();
        Logradouro BuscarCEP(string CEP);
    }
    public class EnderecosRepository : IEnderecosRepository
    {
        private readonly IProfissionaisRepository profissionaisRepository;

        public EnderecosRepository(IProfissionaisRepository profissionaisRepository)
        {
            this.profissionaisRepository = profissionaisRepository;
        }

        public async Task<List<Endereco>> GetEnderecos()
        {
            var profissionais = await profissionaisRepository.GetProfissionais();
            List<Endereco> enderecos = new List<Endereco>();
            List<Endereco> enderecosFiltragem = new List<Endereco>();
            var Endereco = new Endereco();


            foreach (var profissional in profissionais)
            {


                var endereco = new Endereco();

                endereco.Cidade = profissional.Cidade;
                endereco.UF = profissional.UF;
                enderecos.Add(endereco);
            }

            return enderecos;
        }
        /// <summary>
        /// Faz uma Requisição a API do viacep
        /// </summary>
        /// <param name="CEP">Tem como parametro um string CEP</param>
        /// <returns>Retorna uma entidade de Logradouro</returns>
        public Logradouro BuscarCEP(string CEP)
        {
            //Verificando se o CEP é Valido
            CEP = new string(CEP.Where(char.IsDigit).ToArray());
            if (CEP.Length < 8 || CEP.Length > 8)
            {
                return null;
            }
            //Fim da Verificação

            //Instanciando um http client para receber a resposta da requisição
            var cliente = new HttpClient();

            //Formatando o Caminho da Requisição para Receber o CEP indicado no inicio do metodo
            string url = string.Format("/ws/{0}/json/", CEP);

            //Fasendo uma Requisição utilizando a string já formatada
            cliente.BaseAddress = new Uri("https://viacep.com.br");
            cliente.DefaultRequestHeaders.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            var response = cliente.GetAsync(url).Result;
            var logradouro = response.Content.ReadAsAsync<Logradouro>().Result;

            return logradouro;
        }
    }
}
