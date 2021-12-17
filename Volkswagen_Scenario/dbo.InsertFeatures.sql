CREATE PROCEDURE [dbo].InsertFeatures
(
	@Model varchar(50),
	@ft_wheels varchar(MAX),
	@ft_alarm varchar(MAX),
	@ft_headlights varchar(MAX),
	@ft_seats varchar(MAX),
	@ft_radio varchar(MAX),
	@ft_locking varchar(MAX),
	@ft_windows varchar(MAX),
	@ft_airbags varchar(MAX),
	@ft_control varchar(MAX)
)
AS
INSERT INTO [Features] ([Model], [ft_wheels], [ft_alarm], [ft_headlights], [ft_seats], [ft_radio], [ft_locking], [ft_windows], [ft_airbags], [ft_control]) 
VALUES (@Model, @ft_wheels, @ft_alarm, @ft_headlights, @ft_seats, @ft_radio, @ft_locking, @ft_windows, @ft_airbags, @ft_control);
