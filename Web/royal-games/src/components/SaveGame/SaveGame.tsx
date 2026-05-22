import React, { useEffect, useState } from 'react'
import styles from '@/components/SaveGame/SaveGame.module.css'
import { Alex_Brush } from 'next/font/google'
import { cadastrarJogos } from '@/pages/api/jogoService'
import { api } from '@/pages/api/apiService'
import { listarGeneros } from '@/pages/api/generosService'
import { listarPlataformas } from '@/pages/api/plataformasService'
import { listarClassificacao } from '@/pages/api/classificacaoService'
import Link from 'next/link'
import { verificarAutenticacao } from '@/utils/auth'
import { Router } from 'next/router'

interface Classificacao {
    classificacaoId: number;
    classificacaoNome: string;
}

interface Genero {
    generoId: number,
    nome: string
}

interface Plataforma {
    plataformaId: number,
    nome: string
}

const SaveGame = () => {
    const [classificacao, setClassificacao] = useState<Classificacao[]>([])
    const [generos, setGeneros] = useState<Genero[]>([])
    const [plataformas, setPlataformas] = useState<Plataforma[]>([])

    const [nome, setNome] = useState<string>("")
    const [valor, setValor] = useState<string>("")
    const [descricao, setDescricao] = useState<string>("")
    const [imagem, setImagem] = useState<File | null>(null)
    const [classificacaoSelecionada, setClassificacaoSeleciona] = useState<number[]>([])
    const [generosSelecionados, setGenerosSelecionados] = useState<number[]>([])
    const [plataformasSelecionadas, setPlataformasSelecionadas] = useState<number[]>([])

    async function listarGeneroSel() {
        const lista = await listarGeneros();
        setGeneros(lista);
        return generos;
    }

    async function listarPlataformasSel() {
        const lista = await listarPlataformas()
        setPlataformas(lista);
        return plataformas;
    }

    async function listarClassificacaoSel() {
        const lista = await listarClassificacao()
        setClassificacao(lista);
        return classificacao;
    }

    const jogo = {
        nome,
        valor,
        descricao,
        imagem,
        generoIds: generosSelecionados,
        classificacaoIndicativaId: classificacaoSelecionada,
        plataformaIds: plataformasSelecionadas,
    }

    const router = Router;
    useEffect(() => {
        if(!verificarAutenticacao()){
            router.pus
        }

        listarGeneroSel();
        listarPlataformasSel();
        listarClassificacaoSel();
    }, [])

    return (
        <section id={styles.save_game}>
            <form action="" id={styles.form_save_game} className='layout-grid'>
                <div id="top">
                    <h2 id={styles.titulo_form}>Cadastrar novo jogo</h2>
                </div>

                <div id={styles.middle} className='layout-grid'>
                    <div id={styles.side1}>
                        <div id={styles.row1}>
                            <div id={styles.inpt1}>
                                <label htmlFor="game-name">Nome</label>
                                <input type="text" name='game-name' onChange={(e) => setNome(e.target.value)} />
                            </div>
                        </div>

                        <div id={styles.row2}>
                            <div id={styles.inpt2}>
                                <label htmlFor="game-price">valor</label>
                                <input type="text" name='game-price' id={styles.inpt_price} onChange={(e) => setValor(e.target.value)} />
                            </div>

                            <div id={styles.inpt3}>
                                <label htmlFor="game-genre">Gênero</label>
                                <select name='game-genere' className={styles.select}
                                    multiple
                                    value={generosSelecionados.map(String)}
                                    onChange={(e) => setGenerosSelecionados(
                                        Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                    )}>
                                    {generos.map((item) => (
                                        <option
                                            key={item.generoId}
                                            value={item.generoId}>{item.nome}</option>

                                    ))}
                                </select>
                            </div>

                            <div id={styles.inpt4}>
                                <label htmlFor="game-platform">Plataforma</label>
                                <select name='game-platform' className={styles.select}
                                    multiple
                                    value={plataformasSelecionadas.map(String)}
                                    onChange={(e) => setPlataformasSelecionadas(
                                        Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                    )}>
                                    {plataformas.map((item) => (
                                        <option value={item.plataformaId}
                                            key={item.plataformaId}>{item.nome}</option>
                                    ))}
                                </select>
                            </div>
                        </div>

                        <div id={styles.row3}>
                            <div id={styles.inpt5}>
                                <label htmlFor="game-indicative-class">Classificação indicativa</label>
                                <select name='game-indicative-class' className={styles.select} id={styles.slc_class}
                                    value={String(classificacaoSelecionada || "")}
                                    onChange={(e) => setClassificacaoSeleciona(
                                        Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                    )}>
                                    {classificacao.map((item) => (
                                        <option
                                            value={item.classificacaoId}
                                            key={item.classificacaoId}>{item.classificacaoNome}</option>
                                    ))}
                                </select>
                            </div>

                            <div id={styles.inpt6}>
                                <label htmlFor="game-image">Imagem</label>
                                <input type="file" name='game-image' id={styles.inpt_img} onChange={(e) => {
                                    if (e.target.value && e.target.files![0]) {
                                        setImagem(e.target.files![0])
                                    }
                                }} />
                            </div>
                        </div>
                    </div>

                    <div id={styles.side2}>
                        <div id={styles.inpt7}>
                            <label htmlFor="game-description">Descrção</label>
                            <textarea name='game-description' id={styles.textarea} onChange={(e) => setDescricao(e.target.value)}></textarea>
                        </div>
                    </div>
                </div>

                    <button onClick={(e) => {
                        e.preventDefault()
                        cadastrarJogos(jogo)

                    }}>Cadastrar</button>
            </form>
        </section >
    )
}

export default SaveGame