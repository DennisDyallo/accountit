// vite.config.ts
import { defineConfig } from 'vite';
import { resolve } from 'path';

export default defineConfig(({ command, mode }) => ({
  // Base configuration
  build: {
    lib: {
      entry: resolve(__dirname, "src/bridge.ts"),
      name: "DexieInterop",
      fileName: (format) => `dexie-interop.${format}.js`,
      formats: ["iife"], // Use IIFE for direct browser usage
    },
    rollupOptions: {
      // External dependencies that shouldn't be bundled
      external: [],
      output: {
        // Global variables for external packages
        globals: {},
        // Ensure we get a single bundle file
        compact: true,
        // Add banner for debugging
        banner:
          "/* DexieInterop for Blazor - Built: " +
          new Date().toISOString() +
          " */",
        // Configure exports
        exports: "named",
        // Ensure IIFE assigns to window
        extend: true,
      },
    },
    // Output directory (relative to vite.config.ts)
    outDir: "../net/Frontend/wwwroot/js",
    // Clean the output directory before build
    emptyOutDir: true,
    // Source maps for debugging
    sourcemap: mode === "development",
    // Minification options
    minify: mode === "production" ? "terser" : false,
    terserOptions: {
      compress: {
        drop_console: mode === "production",
        drop_debugger: mode === "production",
      },
    },
    // Report bundle size
    reportCompressedSize: true,
    // Maximum chunk size warning (2MB)
    chunkSizeWarningLimit: 2048,
  },
  // Development server config
  server: {
    watch: {
      // Using ignored pattern instead of include
      ignored: ["!**/src/**"],
    },
  },
  // Optimize deps
  optimizeDeps: {
    include: ["dexie"],
  },
  // Enable TypeScript checking
  plugins: [],
  // Resolve configuration
  resolve: {
    alias: {
      "@": resolve(__dirname, "./src"),
    },
  },
  // Define global constants
  define: {
    __VERSION__: JSON.stringify(process.env.npm_package_version),
    __DEV__: mode === "development",
  },
}));