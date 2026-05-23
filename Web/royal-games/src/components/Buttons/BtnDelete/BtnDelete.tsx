import React from 'react'
import styles from '@/components/Buttons/BtnDelete/BtnDelete.module.css'
import { removerJogo } from '@/pages/api/jogoService';

type Props = {
    id: number;
}

export const BtnDelete = ({ id }: Props) => {
    return (
        <button id={styles.btn} onClick={(e) => {
            e.preventDefault()
            removerJogo(id)
        }}>Remover</button>
    )
}
