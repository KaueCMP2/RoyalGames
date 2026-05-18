// Tudo que você colocar aqui vai existir em todas as telas.
// O que normalmente vai aqui:
// CSS global
// Layout padrão (header, footer)
import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { ToastContainer } from "react-toastify";
import { Orbitron } from "next/font/google";

const orbitron = Orbitron({
  variable: "--font-primaria",
  weight: ["400", "500", "600", "700"],
  subsets: ["latin"],
});

export default function App({ Component, pageProps }: AppProps) {
  return (
    <main className={orbitron.variable}>
      <Component {...pageProps} />
      <ToastContainer />
    </main>
  )
}
