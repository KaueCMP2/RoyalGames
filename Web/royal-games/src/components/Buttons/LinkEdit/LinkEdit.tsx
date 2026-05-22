import Link from 'next/link'
import React from 'react'
import styules from '@/components/Buttons/LinkEdit/LinkEdit.module.css'

type Props = {
  id: number
}

export const LinkEdit = ({ id }: Props) => {
  return (
    <Link href={"jogo?id=" + id}>Editar</Link>
  )
}
