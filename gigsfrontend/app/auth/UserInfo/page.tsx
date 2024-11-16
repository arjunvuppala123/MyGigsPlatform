'use client';

import { useUser } from '@auth0/nextjs-auth0/client';
import Image from "next/image";

export default function ProfileClient() {
    // Destructure user, error, and isLoading from the useUser hook
    const { user, error, isLoading } = useUser();

    // Check for loading state
    if (isLoading) return <div>Loading...</div>;

    // Handle error if exists
    if (error) return <div>{error.message}</div>;

    // Render user profile if user exists
    return (
        user && (
            <div>
                <Image
                    src={user.picture || "/default-avatar.png"} // Default avatar in case no picture is available
                    alt={user.name || "User"} // Fallback to "User" if name is missing
                    width={100} // You can customize the width and height as needed
                    height={100}
                />
                <h2>{user.name}</h2>
                <p>{user.email}</p>
            </div>
        )
    );
}
