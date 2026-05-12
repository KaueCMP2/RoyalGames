import Banner from '@/components/Banner/Banner'
import Footer from '@/components/Footer/Footer'
import Header from '@/components/Header/Header'
import SaveGame from '@/components/SaveGame/SaveGame'
import React from 'react'
import styles from '@/pages/home/home.module.css'

const HomePage = () => {
  return (
    <body id={styles.body}>
      <Header />
      <Banner />
      <Footer />
    </body>
  )
}

export default HomePage