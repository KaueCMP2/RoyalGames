import React, { useEffect, useState } from 'react'
import styles from '@/components/GameDetails/GameDetails.module.css'
import formatarValor from '@/utils/formatacao';
import FormatarValor from '@/utils/formatacao';
import { useParams } from 'next/navigation';
import { listarJogos, listarJogosPorId } from '@/pages/api/jogoService';

interface Jogo {
  jogoId: number,
  imgUrl: string,
  nome: string,
  descricao: string,
  plataformaIds: number[],
  generos: string[],
  plataformas: string[],
  classificacaoId: number;
  valor: number,
}

const GameDetails = () => {

  const [jogo, setJogo] = useState<Jogo>();
  const params = useParams();
  const id = params?.id;

  async function buscarJogo() {
    try {
      const response = await listarJogosPorId(Number(id));
      console.log(response)
      
      setJogo(response)
    } catch (error: any) {
      console.log(error.message)
    }
  }

  useEffect(() => {
    if (!id) return;

    setTimeout(() => {
      buscarJogo();
      console.log(jogo?.classificacaoId)
    }, 100)
  }, [id])

  return (
    <main id={styles.main}>
      <div id={styles.content_main} className='layout-grid'>
        <h1>Detalhes do jogo</h1>
        <div id={styles.container_game_details}>
          <div id={styles.content_game_details1}>
            <img src={jogo?.imgUrl} alt="" />
            <div id={styles.container_info}>
              <article id={styles.game_article}>
                <h2>{jogo?.nome}</h2>
                <p>{jogo?.descricao}</p>
              </article>
              <div id={styles.game_details}>
                <p><span>Classificação indicativa: </span> {jogo?.classificacaoId}</p>
                <p><span>Preço: </span>{formatarValor(jogo?.valor)}</p>
                <p><span>Plataformas: </span>{jogo?.plataformas}</p>
                <p><span>Genero: </span>{jogo?.generos}</p>
              </div>
            </div>
          </div>

        </div>
      </div>
    </main >
  )
}

export default GameDetails