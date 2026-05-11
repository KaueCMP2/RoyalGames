// Tudo que você colocar aqui vai existir em todas as telas.
// O que normalmente vai aqui:
// CSS global
// Layout padrão (header, footer)
import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { Fredoka } from "next/font/google";
import { ToastContainer } from "react-toastify";

const fredoka = Fredoka({
  variable: "--font-padrao",
  weight: ["300", "400", "500", "600", "700"],
  subsets: ["latin"],
});

export default function App({ Component, pageProps }: AppProps) {
  return (
    <main className={fredoka.variable}>
      <Component {...pageProps} />
    </main>
  )
}
