package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UpdateAnAccountAgentBotExample
{
    fun updateAnAccountAgentBot()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val agentBotCreateUpdatePayload = AgentBotCreateUpdatePayload()

        try
        {
            val response = AccountAgentBotsApi().updateAnAccountAgentBot(
                accountId = 0,
                id = 0,
                _data = agentBotCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountAgentBotsApi#updateAnAccountAgentBot")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountAgentBotsApi#updateAnAccountAgentBot")
            e.printStackTrace()
        }
    }
}
