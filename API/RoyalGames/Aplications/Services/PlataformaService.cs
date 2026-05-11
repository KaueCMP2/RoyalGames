using RoyalGames.Domains;
using RoyalGames.DTOs.PlataformaDto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;
using System.Linq;

// Service contém as regras de negócio referente a plataforma.
// Faz a ponte entre Controller e Repository.
// Usa-se as DTOs e aplica-se as validações antes de acessar o banco.

namespace RoyalGames.Aplications.Services
{
    public class PlataformaService
    {
        // Interface do repositório usada para acessar o banco de dados.
        private readonly IPlataformaRepository _repository;

        // Construtor que recebe o repositório via Injeção de Dependência.
        public PlataformaService(IPlataformaRepository repository)
        {
            _repository = repository;
        }

        // Retorna todas as plataformas cadastradas no sistema.
        public List<LerPlataformaDto> Listar()
        {
            //Busca as plataformas no banco
            List<Plataforma> plataformas = _repository.Listar();

            // Converte a lista de plataformas em lista de DTO.
            List<LerPlataformaDto> plataformaDto = plataformas.Select(p => new LerPlataformaDto
            {
                PlataformaID = p.PlataformaID,
                Nome = p.Nome
            }).ToList();

            //Retorna a lista convertida.
            return plataformaDto;
        }

        // Retorna uma plataforma específica pelo ID.
        public LerPlataformaDto ObterPorId(int id)
        {
            // Busca a plataforma no repositório.
            Plataforma plataforma = _repository.ObterPorId(id);

            //Caso não encontro envia a DomainEcepxtion.
            if (plataforma == null)
            {
                throw new DomainException("Plataforma não encontrada.");
            }

            // Converte a plataforma para DTO de leitura.
            LerPlataformaDto PlataformaDto = new LerPlataformaDto
            {
                PlataformaID = plataforma.PlataformaID,
                Nome = plataforma.Nome
            };

            return PlataformaDto;
        }

        // Método privado usado apenas dentro do service.
        // Valida se o nome foi preenchido corretamente.
        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        // Adiciona uma nova plataforma no sistema.
        public void Adicionar(CriarPlataformaDto criarDto)
        {
            // Valida se o nome foi informado.
            ValidarNome(criarDto.Nome);

            // Verificação se já existe uma plataforma com o mesmo nome.
            if (_repository.NomeExiste(criarDto.Nome))
            {
                throw new DomainException("Plataforma já existente.");
            }

            // Converte DTO para Plataforma.
            Plataforma plataforma = new Plataforma
            {
                Nome = criarDto.Nome
            };

            //Adiciona a plataforma no repositório para salvar no banco.
            _repository.Adicionar(plataforma);
        }

        // Atualiza uma plataforma existente.
        public void Atualizar(int id, CriarPlataformaDto criarDto)
        {
            // Validação se o campo nome foi preenchido.
            ValidarNome(criarDto.Nome); 
            
            //Busca a plataforma no banco
            Plataforma plataformaBanco = _repository.ObterPorId(id);

            //Se naõ ecnontrar envia DomainException
            if (plataformaBanco == null)
            {
                throw new DomainException("Categoria não foi encontrada.");
            }

            // Verifica se já existe outra plataforma com o mesmo nome.
            // O parâmetro PlataformaIdAtual evita que ele compare com ele mesmo.
            // categoriaIdAtual: id -> categoriaIdAtual recebe id
            if (_repository.NomeExiste(criarDto.Nome, PlataformaIdAtual: id))
            {
                throw new DomainException("Já existe outra categoria com esse nome.");
            }

            // Atualiza o npme.
            plataformaBanco.Nome = criarDto.Nome;
            _repository.Atualizar(plataformaBanco);
        }

        // Remove uma plataforma do sistema.
        public void Remover(int id)
        {
            // Busca a plataforma no banco
            Plataforma plataformaBanco = _repository.ObterPorId(id);

            //Se não envia a DomainException
            if (plataformaBanco == null)
            {
                throw new DomainException("Plataforma não encontrada.");
            }

            // Solicita ao repositório a remoção.
            _repository.Remover(id);
        }

    }
}
