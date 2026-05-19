import React from 'react'
import styles from '@/components/GameDetails/GameDetails.module.css'
import formatarValor from '@/utils/formatacao';
import FormatarValor from '@/utils/formatacao';

type JogoRecebido = {
  jogoId: number,
  imgUrl: string,
  nome: string,
  descricao: string,
  plataformaIds: number[],
  generoIds: number[]
  classificacaoId: number;
  valor: number,
}

const GameDetails = (jogo: JogoRecebido) => {
  return (
    <main id={styles.main}>
      <div id={styles.content_main} className='layout-grid'>
        <h1>Detalhes do jogo</h1>
        <div id={styles.container_game_details}>
          <div id={styles.content_game_details1}>
            <img src={jogo.imgUrl} alt="" />
            <div id={styles.container_info}>
              <article id={styles.game_article}>
                <h2>{jogo.nome}</h2>
                <p>{jogo.descricao}</p>
              </article>
              <div id={styles.game_details}>
                <p><span>Classificação indicativa:</span> {jogo.classificacaoId}</p>
                <p><span>Preço:</span>{FormatarValor(jogo.valor)}</p>
                <p><span>Plataformas:</span>{jogo.plataformaIds}</p>
                <p><span>Genero:</span>{jogo.generoIds}</p>
              </div>
            </div>
          </div>

        </div>
      </div>
    </main >
  )
}

export default GameDetails