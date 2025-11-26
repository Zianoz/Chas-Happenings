export function getUserRole() {
  return localStorage.getItem("role");
}

export function isAdmin() {
  return getUserRole() === "Admin";
}

export function isLoggedIn() {
  return !!localStorage.getItem("role");
}
