using RoyalGames.Aplications.Conversions;
using RoyalGames.Domains;
using RoyalGames.DTOs.JogoDto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;
using VHBurger.Aplications.Rules;

namespace RoyalGames.Aplications.Services
{
    public class JogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        // Para cada Jogo que veio do banco
        // Crie um DTO só com o que a requisição/front precisa.
        public List<LerJogoDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();

            // SELECT percorre cada Jogo e transforma em DTO -> LerJogoDto
            List<LerJogoDto> jogoDto =
                jogos.Select(JogoParaDto.ConverterParaDto).ToList();

            return jogoDto;
        }

        public LerJogoDto ObterPorId(int id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
            {
                throw new DomainException("Jogo não encontrado");
            }

            // converte o Jogo encontrado para DTO e devolve
            return JogoParaDto.ConverterParaDto(jogo);
        }

        private static void ValidarCadastro(CriarJogoDto jogoDto)
        {
            if (string.IsNullOrWhiteSpace(jogoDto.Nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }

            if (jogoDto.Valor < 0)
            {
                throw new DomainException("Preço deve ser maior que zero.");
            }

            if (string.IsNullOrWhiteSpace(jogoDto.Descricao))
            {
                throw new DomainException("Descrição é obrigatória.");
            }

            if (jogoDto.Imagem == null || jogoDto.Imagem.Length == 0)
            {
                throw new DomainException("Imagem é obrigatória.");
            }

            if (jogoDto.GeneroIds == null || jogoDto.GeneroIds.Count == 0)
            {
                throw new DomainException("Jogo deve ter ao menos uma categoria.");
            }
        }

        public byte[] ObterImagem(int id)
        {
            byte[] imagem = _repository.ObterImagem(id);

            if (imagem == null || imagem.Length == 0)
            {
                throw new DomainException("Imagem não encontrada");
            }

            return imagem;
        }

        public LerJogoDto Adicionar(CriarJogoDto jogoDto, int usuarioId)
        {
            ValidarCadastro(jogoDto);

            if (_repository.NomeExiste(jogoDto.Nome))
            {
                throw new DomainException("Jogo já existente");
            }

            Jogo Jogo = new Jogo
            {
                Nome = jogoDto.Nome,
                Valor = jogoDto.Valor,
                Descricao = jogoDto.Descricao,
                Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem),
                StatusJogo = true,
            };

            _repository.Adicionar(Jogo, jogoDto.GeneroIds);

            return JogoParaDto.ConverterParaDto(Jogo);
        }

        public LerJogoDto Atualizar(int id, AtualizarJogoDto jogoDto)
        {
            HorarioAlteracaoJogo.ValidarHorario();

            Jogo jogoBanco = _repository.ObterPorId(id);

            if (jogoBanco == null)
            {
                throw new DomainException("Jogo não encontrado.");
            }

            // JogoIdAtual: -> dois pontos serve para passar o valor do parametro
            if (_repository.NomeExiste(jogoDto.Nome, JogoIdAtual: id))
            {
                throw new DomainException("Já existe outro Jogo com esse nome.");
            }

            if (jogoDto.CategoriaIds == null || jogoDto.CategoriaIds.Count == 0)
            {
                throw new DomainException("Jogo deve ter ao menos uma categoria.");
            }

            if (jogoDto.Valor < 0)
            {
                throw new DomainException("Preço deve ser maior que zero.");
            }

            jogoBanco.Nome = jogoDto.Nome;
            jogoBanco.Valor = jogoDto.Valor;
            jogoBanco.Descricao = jogoDto.Descricao;

            if (jogoDto.Imagem != null && jogoDto.Imagem.Length > 0)
            {
                jogoBanco.Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem);
            }

            if (jogoDto.StatusJogo.HasValue)
            {
                jogoBanco.StatusJogo = jogoDto.StatusJogo.Value;
            }

            _repository.Atualizar(jogoBanco, jogoDto.CategoriaIds);

            return JogoParaDto.ConverterParaDto(jogoBanco);

        }

        public void Remover(int id)
        {
            HorarioAlteracaoJogo.ValidarHorario();

            Jogo Jogo = _repository.ObterPorId(id);

            if (Jogo == null)
                throw new DomainException("Jogo não encontrado.");

            _repository.Remover(id);
        }
    }
}
