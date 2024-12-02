import { getSession, Claims } from "@auth0/nextjs-auth0";
import Home from "@/app/Home";

interface ExtendedClaims extends Claims {
  name: string;
  email: string;
}

const HomePage = async ({ req, res }: { req: any; res: any }) => {
  const session = await getSession(req, res);

  if (!session || !session.accessToken) {
    return <Home />; // Return Home without user and accessToken if session is not available
  }

  const user = session.user as ExtendedClaims;
  const { accessToken } = session;

  return <Home user={user} accessToken={accessToken} />;
};

export default HomePage;
