import { Html, Head, Main, NextScript } from "next/document";

export default function Document() {
  return (
    <Html lang="pt-br">
      <Head />
      <body>
        <Main />
        {/* injeta os scripts que fazem o React funcionar no navegador. */}
        <NextScript />
      </body>
    </Html>
  );
}
