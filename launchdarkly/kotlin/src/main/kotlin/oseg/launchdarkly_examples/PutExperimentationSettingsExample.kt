package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PutExperimentationSettingsExample
{
    fun putExperimentationSettings()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val randomizationUnits1 = RandomizationUnitInput(
            randomizationUnit = "user",
            standardRandomizationUnit = RandomizationUnitInput.StandardRandomizationUnit.organization,
        )

        val randomizationUnits = arrayListOf<RandomizationUnitInput>(
            randomizationUnits1,
        )

        val randomizationSettingsPut = RandomizationSettingsPut(
            randomizationUnits = randomizationUnits,
        )

        try
        {
            val response = ExperimentsApi().putExperimentationSettings(
                projectKey = "the-project-key",
                randomizationSettingsPut = randomizationSettingsPut,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ExperimentsApi#putExperimentationSettings")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ExperimentsApi#putExperimentationSettings")
            e.printStackTrace()
        }
    }
}
