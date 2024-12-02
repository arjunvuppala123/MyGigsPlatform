// app/page.tsx (or app/home/page.tsx, depending on structure)
import { getSession, Claims } from "@auth0/nextjs-auth0";
import Home from "@/app/Home";

interface ExtendedClaims extends Claims {
  name: string;
  email: string;
}

export async function generateMetadata() {
  return {
    title: "Home - Gigs Platform",
    description: "Empowering Independent Work with Our Gigs Platform.",
    keywords: "freelance, gigs, independent work, jobs",
  };
}

const HomePage = async () => {
  const session = await getSession();

  if (!session || !session.accessToken) {
    // No session, render Home without user data
    return <Home />;
  }

  const user = session.user as ExtendedClaims;
  const { accessToken } = session;

  return <Home user={user} accessToken={accessToken} />;
};

export default HomePage;
