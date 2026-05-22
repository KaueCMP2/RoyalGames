import React, { useEffect, useState } from 'react'
import styles from '@/components/GameDetails/GameDetails.module.css'
import formatarValor from '@/utils/formatacao';
import FormatarValor from '@/utils/formatacao';
import { useParams } from 'next/navigation';
import { listarJogos, listarJogosPorId } from '@/pages/api/jogoService';

interface Jogo {
  jogoId: number,
  nome: string,
  valor: number,
  descricao: string,
  statusJogo: boolean,
  imgUrl: string,
  generoIds: number[],
  generos: string[],
  plataformaIds: number[],
  plataformas: string[],
  classificacaoIndicativaId: number,
  classificacaoIndicativa: string[];
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
      console.log(jogo?.classificacaoIndicativa)
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
                <div className={styles.container_valor}>
                  <p>Preço: </p>
                  <span>{formatarValor(jogo?.valor)}</span>
                </div>

                <div className={styles.container_classificacao}>
                  <p>Classificação indicativa: </p>
                  <span> {jogo?.classificacaoIndicativa}</span>
                </div>

                <div className={styles.container_plataformas}>
                  <p>Plataformas: </p>
                  {jogo?.plataformas.length != 0 ? jogo?.plataformas.map((item) => (
                    <span> {jogo?.plataformas}</span>
                  )) : ("Plataformas não inseridas..."
                  )}
                </div>

                <div className={styles.container_generos}>
                  <p>Genero:</p>
                  {jogo?.generos.length != 0 ? jogo?.generos.map((item) => (
                    <span> {item}</span>
                  )) : ("Genero não inseridas..."
                  )}
                </div>
              </div>
            </div>
          </div>

        </div>
      </div>
    </main >
  )
}

export default GameDetails