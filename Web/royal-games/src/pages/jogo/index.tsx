import SaveGame from '@/components/SaveGame/SaveGame'
import styles from '@/pages/salvar-jogo/salvar.module.css'
import { verificarAutenticacao } from '@/utils/auth'
import { useRouter } from 'next/router'

import React, { useEffect } from 'react'

const index = () => {
    return (
        <>
            <SaveGame />
        </>
    )
}

export default index
