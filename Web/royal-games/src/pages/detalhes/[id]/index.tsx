import Footer from '@/components/Footer/Footer'
import Header from '@/components/Header/Header'
import React, { useEffect } from 'react'
import styles from '@/pages/game-details/game-details.module.css'
import GameDetails from '@/components/GameDetails/GameDetails'
import { api } from '@/pages/api/apiService'

interface JogoRecebido {
  jogoId: number,
  imgUrl: string,
  nome: string,
  descricao: string,
  plataformaIds: number[],
  generoIds: number[]
  classificacaoId: number;
  valor: number,
}

const Pag_GameDetails = (jogo: JogoRecebido) => {

  const Listar = () => {
    const response = api.get("Produto");
  }

  useEffect(() => {

  }, [])

  return (
    <>
      <Header />
      <GameDetails/>
      <Footer />
    </>
  )
}

export default Pag_GameDetails