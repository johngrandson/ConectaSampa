using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;

namespace ChatBot.Formulario
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Desculpe não entendi \"{0}\".")]
    public class Pedido
    {
        public Opcao Opcao { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public static IForm<Pedido> BuildForm()
        {
            var form = new FormBuilder<Pedido>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "sim", "yes", "s", "y", "yep", "ok" };
            form.Configuration.No = new string[] { "não", "nao", "no", "not", "n" };
            form.Message("Olá, seja bem vindo ao Busy, em que posso lhe ajudar?");
            form.OnCompletion(async (context, pedido) =>
            {
                //Salvar na base de dados
                //Gerar pedido
                //Integrar com seriço xpto.
                await context.PostAsync("Sua solicitacao foi enviada, obrigado!");
            });
            return form.Build();
        }
    }

    [Describe("Opcao")]
    public enum Opcao
    {
        [Terms("criticas", "elogios", "opiniao", "sobre o app")]
        [Describe("Criticas e elogios sobre o app")]
        Feedback = 1,

        [Terms("relatar", "panico", "help", "socorro", "abuso", "denuncia")]
        [Describe("Denunciar abuso ou assalto")]
        Relatar = 2,

        [Terms("onibus", "onibus proximos", "onibus por perto", "veiculos proximos", "veiculos", "veiculo mais proximo", "qual onibus pegar?")]
        [Describe("Veiculos Proximos")]
        VeiculoProximo = 3,

        [Terms("pontos", "pontos proximos", "pontos por perto", "paradas proximas", "paradas por perto", "qual parada mais proxima?")]
        [Describe("Pontos de Onibus Proximos")]
        PontoProximo = 4,
    }

}