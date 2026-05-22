import styles from '@/components/CreateGender/CreateGender.module.css'
import { verificarAutenticacao } from '@/utils/auth';
import { useRouter } from 'next/router'
import React, { useEffect } from 'react'

export const CreateGender = () => {
  const router = useRouter();

  useEffect(() => {
    if (!verificarAutenticacao()) {
      router.push("home");
    }

  }, [])

  return (
    <div>CreateGender</div>
  )
}
