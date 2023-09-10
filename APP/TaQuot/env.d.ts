/// <reference types="vite/client" />
interface ImportMetaEnv{
  readonly VITE_API_URL_COLLAB : string;
  readonly VITE_API_URL_ADMIN : string;
  readonly VITE_BASE_URL : string;
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}
