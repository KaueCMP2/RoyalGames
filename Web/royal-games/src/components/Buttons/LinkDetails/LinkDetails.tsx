import Link from 'next/link'
import React from 'react'
import styles from '@/components/Buttons/LinkDetails/LinkDetails.module.css'

type Props ={
    id: number;
}
export const LinkDetails = ({id}: Props) => {
    return (
        <Link href={`detalhes/${id}`} id={styles.link} onClick={() => console.log(id)}>Detalhes</Link>
    )
}
