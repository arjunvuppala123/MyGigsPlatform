import { getSession } from '@auth0/nextjs-auth0';
import Image from "next/image";

export default async function ProfileServer() {
    const session    = await getSession();

    return (
        session?.user && (
            <div>
                <Image
                    src={session?.user.picture || "/default-avatar.png"} // Default avatar in case no picture is available
                    alt={session?.user.name || "User"} // Fallback to "User" if name is missing
                    width={100} // You can customize the width and height as needed
                    height={100}
                />
                <h2>{session?.user.name}</h2>
                <p>{session?.user.email}</p>
            </div>
        )
    );
}