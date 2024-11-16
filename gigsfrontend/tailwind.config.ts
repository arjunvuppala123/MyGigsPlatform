import type { Config } from "tailwindcss";

export default {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        navbar: {
          backgroundColor: '#347928',
          color: '#FFFBE6',
          accent: '#C0EBA6'
        },
        website: {
          backgroundColor: '#C0EBA6',
          color: '#FFFBE6'
        },
        footer: {
          backgroundColor: '#FCCD2A',
          color: '#FFFBE6'
        }
      },
    },
  },
  plugins: [],
} satisfies Config;
