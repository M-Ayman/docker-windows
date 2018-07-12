Feature: Viewer Sign Up
	As a viewer interested in the webinar
	I want to sign up to register
	So that I can watch the webinar

Scenario Outline: Sign Up with Valid Details
	Given I browse to the Sign Up Page at "http://after_nginx_1/app/SignUp"
	And I enter details '<FirstName>' '<LastName>' '<EmailAddress>' '<Country>' '<Role>'
	When I press Go
	Then I am shown the Thank You page
	And my details are saved

Examples:
	| FirstName | LastName | EmailAddress         | Country        | Role                   |
	| Viewer    | A        | a.viewer@company.com | United States  | Developer              |
	| Viewer    | B        | b.viewer@company.com | United Kingdom | Developer              |
	| Viewer    | C        | c.viewer@company.com | United States  | Database Administrator |
	| Viewer    | D        | d.viewer@company.com | United Kingdom | IT Pro                 |
	| Viewer    | E        | e.viewer@company.com | United States  | IT Pro                 |
	| Viewer    | F        | f.viewer@other.com   | Sweden         | Developer              |
	| Viewer    | G        | g.viewer@company.com | United States  | Developer              |
	| Viewer    | H        | h.viewer@company.com | United States  | Architect              |
	| Viewer    | I        | i.viewer@company.com | United Kingdom | Developer              |
	| Viewer    | J        | j.viewer@company.com | United States  | Architect              |
	| Viewer    | K        | k.viewer@other.com   | Sweden         | Database Administrator |
	| Viewer    | L        | l.viewer@company.com | United Kingdom | Developer              |
	| Viewer    | M        | m.viewer@company.com | Sweden         | Architect              |
	| Viewer    | N        | n.viewer@company.com | United Kingdom | Developer              |
	| Viewer    | O        | o.viewer@company.com | United States  | IT Pro                 |
	| Viewer    | P        | p.viewer@other.com   | Sweden         | Developer              |
	| Viewer    | Q        | q.viewer@other.com   | Sweden         | Developer              |
	| Viewer    | R        | r.viewer@company.com | United Kingdom | IT Pro                 |
	| Viewer    | S        | s.viewer@company.com | United States  | Architect              |
	| Viewer    | T        | t.viewer@company.com | United Kingdom | Database Administrator |
	| Viewer    | U        | u.viewer@company.com | United States  | Architect              |
	| Viewer    | V        | v.viewer@other.com   | Sweden         | Developer              |
	| Viewer    | W        | w.viewer@company.com | United States  | Architect              |
	| Viewer    | X        | x.viewer@company.com | United Kingdom | Developer              |
	| Viewer    | Y        | y.viewer@company.com | United States  | Architect              |
	| Viewer    | Z        | z.viewer@other.com   | Sweden         | Developer              |