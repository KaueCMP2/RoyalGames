import React, { useEffect, useState } from 'react'
import styles from '@/components/SaveGame/SaveGame.module.css'
import { Alex_Brush } from 'next/font/google'
import { cadastrarJogos } from '@/pages/api/jogoService'
import { api } from '@/pages/api/apiService'
import { listarGeneros } from '@/pages/api/generosService'
import { listarPlataformas } from '@/pages/api/plataformasService'
import { listarClassificacao } from '@/pages/api/classificacaoService'

interface Classificacao {
    ClassificacaoId: number;
    Nome: string;
}

interface Genero {
    GeneroId: number,
    Nome: string
}

interface Plataforma {
    PlataformaId: number,
    Nome: string
}

const SaveGame = () => {
    const [classificacoes, setClassificacoes] = useState<Classificacao[]>([])
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
    }

    async function listarPlataformasSel() {
        const lista = await listarPlataformas()
        setPlataformas(lista);
    }

    async function listarClassificacaoSel() {
        const lista = await listarClassificacao()
        setClassificacoes(lista);
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

    useEffect(() => {
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
                                        <option value={item.GeneroId}
                                            key={item.GeneroId}>{item.Nome}</option>
                                    ))}
                                </select>
                            </div>

                            <div id={styles.inpt4}>
                                <label htmlFor="game-indicative-class">Classificação indicativa</label>
                                <select name='game-indicative-class' className={styles.select}
                                    multiple
                                    value={classificacaoSelecionada.map(String)}
                                    onChange={(e) => setClassificacaoSeleciona(
                                        Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                    )}>
                                    {classificacoes.map((item) => (
                                        <option
                                            key={item.ClassificacaoId}
                                            value={item.ClassificacaoId}>{item.Nome}</option>
                                    ))}
                                </select>
                            </div>
                        </div>

                        <div id={styles.row3}>
                            <div id={styles.inpt5}>
                                <label htmlFor="game-platform">Plataforma</label>
                                <select name='game-platform' className={styles.select}
                                    multiple
                                    value={plataformasSelecionadas.map(String)}
                                    onChange={(e) => setPlataformasSelecionadas(
                                        Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                    )}>
                                    {plataformas.map((item) => (
                                        <option value={item.PlataformaId}
                                            key={item.PlataformaId}>{item.Nome}</option>
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

                <button>Cadastrar</button>
            </form>
        </section >
    )
}

export default SaveGame