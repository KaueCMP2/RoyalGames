using RoyalGames.Exceptions;

namespace VHBurger.Aplications.Rules
{
    public class HorarioAlteracaoJogo
    {
        public static void ValidarHorario()
        {
            var agora = DateTime.Now.TimeOfDay;  // Horario do computador
            var abertura = new TimeSpan(16, 0, 0); // Extrai hora minuto e segundo separado //16h
            var fechamento = new TimeSpan(19, 0, 0);

            // retorna true ou false
            var estaAberto = agora >= abertura && agora <= fechamento;

            //se retornar true
            if (estaAberto)
            {
                throw new DomainException("Jogo só pode ser alterado fora do horário de funcionamento!");
            }
        }
    }
}