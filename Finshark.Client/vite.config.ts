import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from 'tailwindcss'

// https://vitejs.dev/config/
export default defineConfig(({ command, mode, isSsrBuild, isPreview }) => {
  if (command === 'serve') {
    return {
      // dev specific config
      base: `/`,
      plugins: [react()],
      css: {
        postcss: {
          plugins: [tailwindcss()]
        }
      }
    }
  } else {
    // command === 'build'
    return {
      // build specific config
      base: `/FinShark/`,
      plugins: [react()],
      css: {
        postcss: {
          plugins: [tailwindcss()]
        }
      }
    }
  }
})